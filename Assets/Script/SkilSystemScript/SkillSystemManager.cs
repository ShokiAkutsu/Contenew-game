using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystemManager : MonoBehaviour
{
	SkillDeckManager _deckManager;

	private void Start()
	{
		_deckManager = GameObject.FindObjectOfType<SkillDeckManager>();
	}

	void Update()
    {
        CheckPlayerInput(PlayerID.Player_1P);
        CheckPlayerInput(PlayerID.Player_2P);
    }

	private void CheckPlayerInput(PlayerID playerID)
	{
		// �X�L���L�[�ݒ���\���̂���擾
		InputSkillKey config = SkillKeyConfig.GetConfig(playerID);

		// ���̓`�F�b�N
		if (Input.GetKeyDown(config.LeftSkill))
		{
			Debug.Log($"{playerID}���̃X�L��");
			_deckManager.TryActivate(playerID, SkillPosition.Left);
		} 
		else if (Input.GetKeyDown(config.CenterSkill))
		{
			Debug.Log($"{playerID}���̃X�L��");
			_deckManager.TryActivate(playerID, SkillPosition.Center);
		}
		else if (Input.GetKeyDown(config.RightSkill))
		{
			Debug.Log($"{playerID}�E�̃X�L��");
			_deckManager.TryActivate(playerID, SkillPosition.Right);
		}
	}
}