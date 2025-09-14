using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSample1 : MonoBehaviour, ISkillEffect
{
	public void Execute(PlayerID usePlayerID)
	{
		Debug.Log("‚Ü‚Ì‚³‚Î");
	}
}
