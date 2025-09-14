using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIDIdentity : MonoBehaviour
{
	[SerializeField] private PlayerID _playerID;
	public PlayerID PlayerID => _playerID;
}
