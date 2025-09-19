using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickDirector : MonoBehaviour
{
	PlayerDeadManager _dead;
	PlayerIDIdentity _id;
	[SerializeField] bool _gotMode = false;
	bool _isPause = false;
	[SerializeField] float _gotTime = 3f;
	float _timer = -1; // デバッグ用初期値

	void Start()
	{
		_dead = GameObject.FindObjectOfType<PlayerDeadManager>();
		_id = GetComponent<PlayerIDIdentity>();
	}

	private void OnEnable()
	{
		PauseManager.OnPause += Pause;
		PauseManager.OnResume += Resume;
	}

	private void OnDisable()
	{
		PauseManager.OnPause -= Pause;
		PauseManager.OnResume -= Resume;
	}

	private void Update()
	{
		if (!_isPause && _gotMode)
		{
			_timer += Time.deltaTime;

			if(_gotTime <  _timer)
			{
				_gotMode = false;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!_gotMode && collision.gameObject.tag == "Gimmick")
		{
			_timer = 0; // デバッグ用数値を初期化
			_gotMode = true;
			Debug.Log("障害物と当たりました");
			StartCoroutine(_dead.IsContinue(_id.PlayerID));
		}
	}

	// コンテニュー中の当たり判定の無効化
	private void Pause()
	{
		_isPause = true;
	}

	void Resume()
	{
		_isPause = false;
		_timer = 0;
	}
}
