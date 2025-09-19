using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillWow : MonoBehaviour, ISkillEffect
{
	[SerializeField] List<GameObject> _ghost;
	public void Execute(PlayerID usePlayerID)
	{
		int index = Random.Range(0, _ghost.Count - 1);

		Instantiate(_ghost[index], Vector3.zero, Quaternion.identity);
	}
}
