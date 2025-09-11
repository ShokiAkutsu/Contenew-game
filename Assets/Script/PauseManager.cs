using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseManager : MonoBehaviour
{
	// �V���O���g���C���X�^���X
	public static PauseManager Instance { get; private set; }

	// �|�[�Y�C�x���g�ƍĊJ�C�x���g���`
	public static event Action OnPause;
	public static event Action OnResume;

	// �Q�[�����|�[�Y�����ǂ�����ǐՂ���ϐ�
	public bool isPaused { get; private set; } = false;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Update()
	{
		// ESC �L�[�������ꂽ��ꎞ��~�E�ĊJ��؂�ւ���(0819�F�f�o�b�O�p)
		// �R���e�j���[���Ȃ甽�����Ȃ���t���������炢����������
		if (Input.GetButtonDown("Cancel"))
		{
			Debug.Log("�X�C�b�`��");
			Switching();
		}
	}

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
