using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillWallMove : MonoBehaviour, ISkillEffect
{
	[SerializeField] string _objName;

	public void Execute(PlayerID usePlayerID)
	{
		Debug.Log(_objName);
		AnimationDirector.Instance.PlayTrigger(_objName); // ÉAÉjÉÅÇìÆÇ©Ç∑
	}
}
