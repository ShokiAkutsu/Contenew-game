using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNeedle : MonoBehaviour, ISkillEffect
{
	[SerializeField] GameObject _needle;
	[SerializeField] float _fallPos = 5f;

	public void Execute(PlayerID usePlayerID)
	{
		// ‘ŠèƒvƒŒƒCƒ„[‚ÌID‚ğæ“¾
		PlayerID target = usePlayerID == PlayerID.Player_1P ? PlayerID.Player_2P : PlayerID.Player_1P;
		// ‘Šè‘¤‚ÌPosition‚ğæ“¾
		Vector3 targetPos = PlayerIDManager.Instance.GetPlayerPosition(target);

		Instantiate(_needle, new Vector3(targetPos.x, _fallPos), Quaternion.identity);
	}
}
