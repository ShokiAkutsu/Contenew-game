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
		// スキルキー設定を構造体から取得
		InputSkillKey config = SkillKeyConfig.GetConfig(playerID);

		// 入力チェック
		if (Input.GetKeyDown(config.LeftSkill))
		{
			Debug.Log($"{playerID}左のスキル");
			_deckManager.TryActivate(playerID, SkillPosition.Left);
		} 
		else if (Input.GetKeyDown(config.CenterSkill))
		{
			Debug.Log($"{playerID}中のスキル");
			_deckManager.TryActivate(playerID, SkillPosition.Center);
		}
		else if (Input.GetKeyDown(config.RightSkill))
		{
			Debug.Log($"{playerID}右のスキル");
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