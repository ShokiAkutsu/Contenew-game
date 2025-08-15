using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ContinueCost
{
	[SerializeField] int _cost = 1;
	public int Cost => _cost;

	/// <summary>
	/// コンテニューの最低コストを更新する
	/// payCost + 1を変数costに更新
	/// </summary>
	/// <param name="payCost"></param>
	public void Update(int payCost)
	{
		_cost = payCost + 1;
	}
}
