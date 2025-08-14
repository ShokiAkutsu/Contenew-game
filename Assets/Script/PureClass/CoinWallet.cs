using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoinWallet
{
	//�f�o�b�O�pSerializeField
	[SerializeField] int _wallet;
	public int Wallet => _wallet;

	public void Collect(int coinValue)
	{
		_wallet += coinValue;
	}
}
