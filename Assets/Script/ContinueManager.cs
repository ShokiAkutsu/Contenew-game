using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueManager : MonoBehaviour
{
    [Header("コンテニューするための最低コインを格納")]
    [SerializeField] ContinueCost _cost;
    [SerializeField] Canvas _canvas;	//コンテニューキャンバスを登録

	[SerializeField] Text _minCost; //最低減のコスト
	[SerializeField] Text _payCost; //プレイヤーが払うコスト

	int _payValue;
	bool _isDecision = false;
	//1P, 2P用キーコード
	PlayerID _activePlayer;

	PlayerWalletManager _wallet;

	private void Start()
	{
		_canvas.gameObject.SetActive(false);
	}

	/// <summary>
	/// プレイヤーが死んだら呼び出されるメソッド
	/// コンテニューの総括
	/// </summary>
	public IEnumerator PlayerDead(GameObject player)
    {
		//コンテニューするプレイヤーを格納
		_activePlayer = player.GetComponent<PlayerController>().PlayerID;
		//コストの格納
		_wallet = player.GetComponent<PlayerWalletManager>();
		int maxCost = _wallet.CoinValue();	  //Playerの持ち金を最大値
		int minCost = _cost.Value;			 //現在のコンテニューに必要な金額を最低値
		_payValue = minCost;				//必要金額
		
		//獲得コインが必要金額以上あるならコンテニュー
		if (maxCost >= minCost)
		{
			yield return StartCoroutine(ContinueProcess(maxCost, minCost));
		}
		//獲得コインが必要金額未満ならゲームオーバー
		else
		{
			Debug.Log("GameOverの処理を記述するところ");
			//シーン変えるか
		}

		//所持金が減ったことが分かるエフェクトを出したい
	}

	private IEnumerator ContinueProcess(int maxCost, int minCost)
	{
		_isDecision = false;

		//UIの表示
		_canvas.gameObject.SetActive(true);
		_minCost.text = minCost.ToString();
		//操作しているPlayerに合わせて、UIを更新
		_canvas.GetComponentInChildren<ContinueArrow>().UpdateUI(_activePlayer);
		_canvas.GetComponentInChildren<ActiveUIManager>().UpdateUI(_activePlayer);

		//コンテニュー, リタイアボタンが押されるまでループ
		while (!_isDecision)
		{
			//左右操作で支払うコストを増減
			StartCoroutine(KeyDownControl());
			//支払うコストを制限させる
			_payValue = Mathf.Clamp(_payValue, minCost, maxCost);
			//テキストを更新
			_payCost.text = _payValue.ToString();
			// ここで1フレーム待機し、Unityに制御を戻す。
			yield return null;
		}

		//コンテニューの最低コストを更新
		_cost.Update(_payValue);
		//財布の中をpayValue減らす
		_wallet.SetWallet(-_payValue);
		//UIを非表示にする
		_canvas.gameObject.SetActive(false);
	}

	/// <summary>
	/// 支払うコインをキーで増減させる
	/// </summary>
	/// <returns></returns>
	IEnumerator KeyDownControl()
	{
		if (Input.GetKeyDown(InputMove.GetLeftKey(_activePlayer)))
		{
			_payValue--;
		}
		if (Input.GetKeyDown(InputMove.GetRightKey(_activePlayer)))
		{
			_payValue++;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_isDecision = true;
		}

		yield return null;
	}
}
