using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputJumpSetting
{
	[SerializeField] KeyCode jump;
	public KeyCode Jump => jump;
}
