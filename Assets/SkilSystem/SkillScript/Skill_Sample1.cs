using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSample1 : MonoBehaviour, ISkillEffect
{
	public void Execute(PlayerID usePlayerID)
	{
		Vector3 playerPos = PlayerIDManager.Instance.GetPlayerPosition(usePlayerID);

		Debug.Log(playerPos);
		Debug.Log("åƒÇ—èoÇ≥ÇÍÇƒÇ¢Ç‹Ç∑Ç©ÅH");
	}
}
