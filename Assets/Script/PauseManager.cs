using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseManager : MonoBehaviour
{
	// �|�[�Y�C�x���g�ƍĊJ�C�x���g���`
	public static event Action OnPause;
	public static event Action OnResume;

	// �Q�[�����|�[�Y�����ǂ�����ǐՂ���ϐ�
	public bool isPaused { get; private set; } = false;


	/// <summary>
	/// �|�[�Y�ƃR���e�B�j���[��؂�ւ��郁�\�b�h
	/// </summary>
	public void Switching()
	{
		// ���݂̏�Ԃ𔽓]������
		isPaused = !isPaused;

		if (isPaused)
		{
			OnPause?.Invoke();
		}
		else
		{
			OnResume?.Invoke();
		}
	}

	public void On()
	{
		OnPause?.Invoke();
	}

	public void Off()
	{
		OnResume?.Invoke();
	}
}
