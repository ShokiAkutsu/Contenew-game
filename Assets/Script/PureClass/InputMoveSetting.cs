using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputMoveSetting
{
	[SerializeField] KeyCode moveLeft;
	[SerializeField] KeyCode moveRight;

	public KeyCode Left => moveLeft;
	public KeyCode Right => moveRight;
}
