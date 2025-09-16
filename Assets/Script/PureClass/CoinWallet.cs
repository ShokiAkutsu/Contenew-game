using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�����������N���X
/// </summary>
[Serializable]
public class CoinWallet
{
	//�f�o�b�O�pSerializeField
	[SerializeField] int _coins;
	public int Coins => _coins;

	/// <summary>
	/// �l�������R�C���̉��l���������ɔ��f���郁�\�b�h
	/// </summary>
	/// <param name="coinValue"></param>
	public void Collect(int coinValue)
	{
		_coins += coinValue;

		// �؋������Ȃ��悤�ɂ���
		if(_coins < 0) _coins = 0;
	}
}
