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

	int _payValue;
	bool _isDecision = false;
	//1P, 2P用キーコード
	PlayerID _activePlayer;

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
		//コンテニューするプレイヤーを格納
		_activePlayer = player.GetComponent<PlayerController>().PlayerID;
		//コストの格納
		PlayerWalletManager wallet = player.GetComponent<PlayerWalletManager>();
		int maxCost = wallet.CoinValue();	//Playerの持ち金
		int minCost = _cost.Value;			//現在のコンテニューに必要な金額
		_payValue = minCost;				//必要金額
		
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
				KeyDownControl();
				//支払うコストを制限させる
				_payValue = Mathf.Clamp(_payValue, minCost, maxCost);
				//テキストを更新
				_payCost.text = _payValue.ToString();
			}
		}
		//獲得コインが必要金額未満ならゲームオーバー
		else
		{
			Debug.Log("GameOverの処理を記述するところ");
		}
    }

	void KeyDownControl()
	{
		if(Input.GetKeyDown(InputMove.GetLeftKey(_activePlayer)))
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
	}
}
