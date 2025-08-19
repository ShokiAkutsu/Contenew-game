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
	/// コンテニューの最低コストを更新する
	/// payCost + 1を変数costに更新
	/// </summary>
	/// <param name="payCost"></param>
	public void Update(int payCost)
	{
		_value = payCost + 1;
	}
}
