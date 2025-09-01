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
		_playerController.enabled = false;
		_jumpController.enabled = false;
		_angularVelocity = _rb.angularVelocity;
		_velocity = _rb.velocity;
		_rb.Sleep();
	}

	void Resume()
	{
		_playerController.enabled = true;
		_jumpController.enabled = true;
		_rb.WakeUp();
		_rb.angularVelocity = _angularVelocity;
		_rb.velocity = _velocity;
	}
}
