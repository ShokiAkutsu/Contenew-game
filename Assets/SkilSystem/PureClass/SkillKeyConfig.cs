using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillKeyConfig
{
	// プレイヤーごとの設定を保存する辞書
	private static Dictionary<PlayerID, InputSkillKey> _skillConfigs =
		new Dictionary<PlayerID, InputSkillKey>();

	static SkillKeyConfig()
	{
		// 1Pの設定
		_skillConfigs[PlayerID.Player_1P] =
			new InputSkillKey(KeyCode.Q, KeyCode.W, KeyCode.E);

		// 2Pの設定
		_skillConfigs[PlayerID.Player_2P] =
			new InputSkillKey(KeyCode.U, KeyCode.I, KeyCode.O);
	}

	/// <summary>
	/// 各プレイヤーのスキル発動キーを取得するメソッド
	/// </summary>
	/// <param name="player"></param>
	/// <returns></returns>
	public static InputSkillKey GetConfig(PlayerID player)
	{
		return _skillConfigs[player];
	}
}
