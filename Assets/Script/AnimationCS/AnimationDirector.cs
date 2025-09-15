using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �J�[�h�Q�[���̃V�X�e�����ƁAhierarchy��Animation�������Ȃ�
/// Animation�̌o�R�N���X�ŁA�o�^����Animation�𓮍삳����
/// </summary>
public class AnimationDirector : MonoBehaviour
{
    public static AnimationDirector Instance { get; private set; }
	private Dictionary<string, Animator> _animators = new Dictionary<string, Animator>();

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
			return;
		}
	}

	// �A�j���[�^�[��o�^
	public void RegisterAnimator(string objectName, Animator animator)
	{
		_animators[objectName] = animator;
	}

	// �A�j���[�V�����Đ�
	public void PlayTrigger(string objectName)
	{
		if (_animators.TryGetValue(objectName, out Animator animator))
		{
			animator.SetTrigger("isPlay"); // Trigger�ōĐ�(���O������Ă��Ă��쓮)
		}
	}
}
