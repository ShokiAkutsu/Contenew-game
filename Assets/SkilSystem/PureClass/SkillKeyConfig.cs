using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillKeyConfig
{
	// �v���C���[���Ƃ̐ݒ��ۑ����鎫��
	private static Dictionary<PlayerID, InputSkillKey> _skillConfigs =
		new Dictionary<PlayerID, InputSkillKey>();

	static SkillKeyConfig()
	{
		// 1P�̐ݒ�
		_skillConfigs[PlayerID.Player_1P] =
			new InputSkillKey(KeyCode.Q, KeyCode.W, KeyCode.E);

		// 2P�̐ݒ�
		_skillConfigs[PlayerID.Player_2P] =
			new InputSkillKey(KeyCode.U, KeyCode.I, KeyCode.O);
	}

	/// <summary>
	/// �e�v���C���[�̃X�L�������L�[���擾���郁�\�b�h
	/// </summary>
	/// <param name="player"></param>
	/// <returns></returns>
	public static InputSkillKey GetConfig(PlayerID player)
	{
		return _skillConfigs[player];
	}
}
