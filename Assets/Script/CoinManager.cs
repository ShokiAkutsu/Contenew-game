using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 表示されるコインの価値
/// </summary>
public class CoinManager : MonoBehaviour
{
	[Header("コインの枚数・価値")]
	[SerializeField] int _value = 1;
	public int Value => _value;
}
