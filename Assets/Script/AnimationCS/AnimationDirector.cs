using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードゲームのシステムだと、hierarchyのAnimationが動かない
/// Animationの経由クラスで、登録したAnimationを動作させる
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

	// アニメーターを登録
	public void RegisterAnimator(string objectName, Animator animator)
	{
		_animators[objectName] = animator;
	}

	// アニメーション再生
	public void PlayTrigger(string objectName)
	{
		if (_animators.TryGetValue(objectName, out Animator animator))
		{
			animator.SetTrigger("isPlay"); // Triggerで再生(名前が違っていても作動)
		}
	}
}
