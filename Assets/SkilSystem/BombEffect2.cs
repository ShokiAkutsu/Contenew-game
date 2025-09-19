using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect2 : MonoBehaviour
{
	// �t�F�[�h�A�E�g�ɂ����鎞��
	[SerializeField] float _fadeOutTime = 1.0f;

	// �t�F�[�h�A�E�g�������J�n���郁�\�b�h
	public void StartFadeOut()
	{
		StartCoroutine(FadeOutCoroutine());
	}

	// ���X�ɃA���t�@�l�������Ă����R���[�`��
	private IEnumerator FadeOutCoroutine()
	{
		// SpriteRenderer�R���|�[�l���g���擾
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

		// �t�F�[�h�A�E�g�J�n���̐F���擾
		Color startColor = spriteRenderer.color;

		// �o�ߎ��Ԃ��L�^���邽�߂̕ϐ�
		float elapsedTime = 0f;

		// ���[�v����
		while (elapsedTime < _fadeOutTime)
		{
			// �o�ߎ��Ԃ��X�V
			elapsedTime += Time.deltaTime;

			// �o�ߎ��ԂɊ�Â��āA�V�����A���t�@�l���v�Z
			float newAlpha = 1.0f - (elapsedTime / _fadeOutTime);

			// �X�v���C�g�̐F���X�V
			spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

			// ���̃t���[���܂őҋ@
			yield return null;
		}

		// �t�F�[�h�A�E�g������������A���S�ɓ����ɂ���
		spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

		Destroy(gameObject);
	}
}
