using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimeManager : MonoBehaviour
{
    Animator _anim;
	float _pausedTime;

	// Start is called before the first frame update
	void Start()
    {
        _anim = GetComponent<Animator>();
    }

	private void OnEnable()
	{
		PauseManager.OnPause += AnimeStop;
		PauseManager.OnResume += AnimeStart;
	}

	private void OnDisable()
	{
		PauseManager.OnPause -= AnimeStop;
		PauseManager.OnResume -= AnimeStart;
	}

	void AnimeStop()
	{
		_pausedTime = _anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}

	void AnimeStart()
	{
		_anim.Play("AnimationName", 0, _pausedTime);
	}
}
