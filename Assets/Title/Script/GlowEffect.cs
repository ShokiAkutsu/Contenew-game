using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowEffect : MonoBehaviour
{
	[SerializeField] KeyCode _playKey;
	SpriteRenderer spriteRenderer;
	Color _color;
	[SerializeField] float _defaultAlpha = 0.8f; // �L�[��������Ă��Ȃ���Ԃ̒l
	float _maxAlpha = 1f;
	bool _active = false;
	public bool Active => _active;

	private void Start()
	{
		// ���̃Q�[���I�u�W�F�N�g�ɃA�^�b�`����Ă���Sprite Renderer�R���|�[�l���g���擾
		spriteRenderer = GetComponent<SpriteRenderer>();
		// ���݂̐F���擾
		_color = spriteRenderer.color;
	}

	private void Update()
	{
		// �X�y�[�X�L�[�������ꂽ�u��
		if (Input.GetKeyDown(_playKey))
		{
			// �A���t�@�l���ő�ɐݒ�
			_color.a = _maxAlpha;
			_active = true;
		}
		// �X�y�[�X�L�[�������ꂽ�u��
		if (Input.GetKeyUp(_playKey))
		{
			// �A���t�@�l��0.5�i���̒l�A�܂��͔C�ӂ̒l�j�ɖ߂�
			_color.a = _defaultAlpha;
			_active = false;
		}
		// �A���t�@�l�𔽉f
		spriteRenderer.color = _color;
	}
}
