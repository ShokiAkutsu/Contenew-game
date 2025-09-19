using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAutoScale : MonoBehaviour
{
	// �I�u�W�F�N�g�����B����ő�X�P�[��
	[SerializeField] float _maxScale = 3f;
	// �X�P�[���ύX�̑���
	[SerializeField] float _scaleSpeed = 1f;

	private void Update()
	{
		// �I�u�W�F�N�g�̃X�P�[���𖈃t���[���������傫������
		transform.localScale += Vector3.one * _scaleSpeed * Time.deltaTime;

		// �����A�����ꂩ�̎��̃X�P�[�����ݒ肵���ő�X�P�[���𒴂�����
		if (transform.localScale.x >= _maxScale)
		{
			// ���̃Q�[���I�u�W�F�N�g��j������
			Destroy(gameObject);
		}
	}
}
