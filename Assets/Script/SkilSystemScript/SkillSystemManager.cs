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
		// �X�L���L�[�ݒ���\���̂���擾
		InputSkillKey config = SkillKeyConfig.GetConfig(player);

		// ���̓`�F�b�N
		if (Input.GetKeyDown(config.LeftSkill)) Debug.Log($"{player}���̃X�L��");
		else if (Input.GetKeyDown(config.CenterSkill)) Debug.Log($"{player}���̃X�L��");
		else if (Input.GetKeyDown(config.RightSkill)) Debug.Log($"{player}�E�̃X�L��");
	}
}
