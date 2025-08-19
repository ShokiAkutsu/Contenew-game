using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ContinueCost
{
	[SerializeField] int _value = 1;
	public int Value => _value;

	/// <summary>
	/// �R���e�j���[�̍Œ�R�X�g���X�V����
	/// payCost + 1��ϐ�cost�ɍX�V
	/// </summary>
	/// <param name="payCost"></param>
	public void Update(int payCost)
	{
		_value = payCost + 1;
	}
}
