using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoinWallet
{
	//�f�o�b�O�pSerializeField
	[SerializeField] int _coins;
	[SerializeField] PlayerID _playerID;
	public int Coins => _coins;
	public PlayerID PlayerID => _playerID;

	/// <summary>
	/// �l�������R�C���̉��l���������ɔ��f���郁�\�b�h
	/// </summary>
	/// <param name="coinValue"></param>
	public void Collect(int coinValue)
	{
		_coins += coinValue;
	}
}
