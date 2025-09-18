using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Traking : MonoBehaviour
{
	[Header("ホーミング設定")]
	private Transform _target; // 追尾対象
	[SerializeField] private float _speed = 3f; // 移動速度
	[SerializeField] private float _rotationSpeed = 200f; // 回転速度
	[SerializeField] private float _maxHomingAngle = 30f; // 最大旋回角度

	private Rigidbody2D _rb;
	private Vector2 _currentVelocity;

	bool _isPause = false;

	void Start()
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

	void FixedUpdate()
	{
		if (_target == null)
		{
			// ターゲットがない場合は直進
			_rb.velocity = transform.up * _speed;
			return;
		}
		if (!_isPause)
		{
			HomingMovement();
		}
	}

	public void FindTarget(PlayerID targetID)
	{
		_target = PlayerIDManager.Instance.GetPlayerTransform(targetID);
	}

	private void HomingMovement()
	{
		// ターゲットへの方向
		Vector2 targetDirection = (_target.position - transform.position).normalized;

		// 現在の進行方向
		Vector2 currentDirection = transform.up;

		// 角度差を計算
		float angleDifference = Vector2.SignedAngle(currentDirection, targetDirection);

		// 旋回角度を制限
		float maxTurn = _rotationSpeed * Time.fixedDeltaTime;
		float turnAmount = Mathf.Clamp(angleDifference, -maxTurn, maxTurn);

		// 回転を適用
		transform.Rotate(0, 0, turnAmount);

		// 前方（右方向）に移動
		_rb.velocity = transform.up * _speed;
	}

	// デバッグ用に軌道を表示
	void OnDrawGizmos()
	{
		if (_target != null)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, _target.position);
		}
	}

	void Pause()
	{
		_isPause = true;
	}

	void Resume()
	{
		_isPause = false;
	}
}
