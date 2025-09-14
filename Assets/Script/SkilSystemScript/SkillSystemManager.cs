using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystemManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerInput(PlayerID.Player_1P);
        CheckPlayerInput(PlayerID.Player_2P);
    }

	private void CheckPlayerInput(PlayerID player)
	{
		// スキルキー設定を構造体から取得
		InputSkillKey config = SkillKeyConfig.GetConfig(player);

		// 入力チェック
		if (Input.GetKeyDown(config.LeftSkill)) Debug.Log($"{player}左のスキル");
		else if (Input.GetKeyDown(config.CenterSkill)) Debug.Log($"{player}中のスキル");
		else if (Input.GetKeyDown(config.RightSkill)) Debug.Log($"{player}右のスキル");
	}
}
