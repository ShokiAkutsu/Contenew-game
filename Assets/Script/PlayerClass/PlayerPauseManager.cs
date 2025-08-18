using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPauseManager : MonoBehaviour
{
    //Playeräiî[ïœêî
	Rigidbody2D _rb = default;
	float _angularVelocity;
	Vector3 _velocity;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
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
		_angularVelocity = _rb.angularVelocity;
		_velocity = _rb.velocity;
		_rb.Sleep();
	}

	void Resume()
	{
		_rb.WakeUp();
		_rb.angularVelocity = _angularVelocity;
		_rb.velocity = _velocity;
	}
}
