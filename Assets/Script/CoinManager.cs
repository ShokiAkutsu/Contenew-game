using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �\�������R�C���̉��l
/// </summary>
public class CoinManager : MonoBehaviour
{
	[Header("�R�C���̖����E���l")]
	[SerializeField] int _value = 1;
	public int Value => _value;
}
