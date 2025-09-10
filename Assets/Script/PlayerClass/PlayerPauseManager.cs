using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPauseManager : MonoBehaviour
{
    //Player格納変数
	Rigidbody2D _rb = default;
	float _angularVelocity;
	Vector3 _velocity;
	//Player操作スクリプト
	PlayerController _playerController;
	JumpController _jumpController;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		_playerController = GetComponent<PlayerController>();
		_jumpController = GetComponent<JumpController>();
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

	void Pause()
	{
		//Playerの移動処理を無効化する
		_playerController.enabled = false;
		_jumpController.enabled = false;
		//Playerの状態を保存しておく
		_angularVelocity = _rb.angularVelocity;
		_velocity = _rb.velocity;
		_rb.Sleep();
	}

	void Resume()
	{
		//Playerの移動処理を有効化する
		_playerController.enabled = true;
		_jumpController.enabled = true;
		//Playerの状態を再復帰させる
		_rb.WakeUp();
		_rb.angularVelocity = _angularVelocity;
		_rb.velocity = _velocity;
	}
}
