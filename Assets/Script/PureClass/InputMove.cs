using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputMove
{
	public static KeyCode GetLeftKey(PlayerID player)
	{
		return player == PlayerID.Player_1P ? KeyCode.A : KeyCode.J;
	}

	public static KeyCode GetRightKey(PlayerID player)
	{
		return player == PlayerID.Player_1P ? KeyCode.D : KeyCode.L;
	}

	/// <summary>
	/// 入力したキーを判断して、[-1, 0, 1]を返すメソッド
	/// </summary>
	/// <param name="player"></param>
	/// <returns></returns>
	public static float GetHorizontalAxis(PlayerID player)
	{
		float axis = 0f;

		if (Input.GetKey(GetLeftKey(player)))
		{
			axis -= 1f;
		}
		else if (Input.GetKey(GetRightKey(player))) 
		{
			axis += 1f;
		}

		return axis;
	}
}
