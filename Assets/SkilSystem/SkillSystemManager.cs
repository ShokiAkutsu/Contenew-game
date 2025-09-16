using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystemManager : MonoBehaviour
{
	SkillDeckManager _deckManager;
	bool _isPause = false;

	private void Start()
	{
		_deckManager = GameObject.FindObjectOfType<SkillDeckManager>();
	}

	private void OnEnable()
	{
		PauseManager.OnPause += Pause;
		PauseManager.OnResume += Resume;
	}

	private void OnDisable()
	{
		PauseManager.OnPause -= Pause;
		PauseManager.OnResume -= Resume;
	}

	void Update()
    {
		if(!_isPause)
		{
			CheckPlayerInput(PlayerID.Player_1P);
			CheckPlayerInput(PlayerID.Player_2P);
		}
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

	private void Pause()
	{
		_isPause = true;
	}

	void Resume()
	{
		_isPause = false;
	}
}