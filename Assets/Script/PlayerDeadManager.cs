using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadManager : MonoBehaviour
{
	PauseManager _pause;
	ContinueManager _continue;

	private void Start()
	{
		_pause = GameObject.FindObjectOfType<PauseManager>();
		_continue = GameObject.FindObjectOfType<ContinueManager>();
	}

	public IEnumerator IsContinue(GameObject player)
    {
		//�Q�[���œ����Ă������̂��~
		_pause.On();
		//�R���e�j���[�̏������I���܂őҋ@
		yield return StartCoroutine(_continue.PlayerDead(player));

		Debug.Log("�R���e�j���[�̏I��");
		//�Q�[���̍ĊJ
		_pause.Off();
    }
}
