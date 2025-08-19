using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueManager : MonoBehaviour
{
    [Header("コンテニューするための最低コインを格納")]
    [SerializeField] ContinueCost _cost;
    [SerializeField] Canvas _canvas;

	[SerializeField] Text _minCost; //最低減のコスト
	[SerializeField] Text _payCost; //プレイヤーが払うコスト

	int _walletValue;
	bool _isDecision = false;
	//1P, 2P用キーコード
	KeyCode _keyLeft;
	KeyCode _keyRight;

	private void Start()
	{
		_canvas.gameObject.SetActive(false);
	}

	/// <summary>
	/// プレイヤーが死んだら呼び出されるメソッド
	/// コンテニューの総括
	/// </summary>
	public void PlayerDead(GameObject player)
    {
		PlayerWalletManager wallet = player.GetComponent<PlayerWalletManager>();
		//Cost変数の定義
		int maxCost = wallet.CoinValue();	//Playerの持ち金
		int minCost = _cost.Value;			//現在のコンテニューに必要な金額
		_walletValue = minCost;				//

		//獲得コインが必要金額以上あるならコンテニュー
		if (maxCost >= minCost)
		{
			_isDecision = false;

			//UIの表示
			_canvas.gameObject.SetActive(true);
			_minCost.text = minCost.ToString();

			//コンテニュー, リタイアボタンが押されるまでループ
			while (!_isDecision)
			{
				//左右操作で支払うコストを増減
				KeyDownController();
				//支払うコストを制限させる
				_walletValue = Mathf.Clamp(_walletValue, minCost, maxCost);
				//テキストを更新
				_payCost.text = _walletValue.ToString();
			}
		}
		//獲得コインが必要金額未満ならゲームオーバー
		else
		{
			Debug.Log("GameOverの処理を記述するところ");
		}
    }

	void KeyDownController()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			_walletValue--;
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			_walletValue++;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_isDecision = true;
		}
	}
}
