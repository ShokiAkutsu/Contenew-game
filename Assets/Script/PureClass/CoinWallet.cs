using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーが持つ所持金クラス
/// </summary>
[Serializable]
public class CoinWallet
{
	//デバッグ用SerializeField
	[SerializeField] int _coins;
	//[SerializeField] PlayerID _playerID;
	public int Coins => _coins;
	//public PlayerID PlayerID => _playerID;
	event Action<PlayerID, int> OnCoinsChanged;

	/// <summary>
	/// 獲得したコインの価値を所持金に反映するメソッド
	/// </summary>
	/// <param name="coinValue"></param>
	public void Collect(int coinValue)
	{
		_coins += coinValue;

		// 借金をしないようにする
		if(_coins < 0) _coins = 0;
	}
}
