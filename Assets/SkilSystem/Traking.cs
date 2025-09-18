using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Traking : MonoBehaviour
{
	[Header("�z�[�~���O�ݒ�")]
	private Transform _target; // �ǔ��Ώ�
	[SerializeField] private float _speed = 3f; // �ړ����x
	[SerializeField] private float _rotationSpeed = 200f; // ��]���x
	[SerializeField] private float _maxHomingAngle = 30f; // �ő����p�x

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
			// �^�[�Q�b�g���Ȃ��ꍇ�͒��i
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
		// �^�[�Q�b�g�ւ̕���
		Vector2 targetDirection = (_target.position - transform.position).normalized;

		// ���݂̐i�s����
		Vector2 currentDirection = transform.up;

		// �p�x�����v�Z
		float angleDifference = Vector2.SignedAngle(currentDirection, targetDirection);

		// ����p�x�𐧌�
		float maxTurn = _rotationSpeed * Time.fixedDeltaTime;
		float turnAmount = Mathf.Clamp(angleDifference, -maxTurn, maxTurn);

		// ��]��K�p
		transform.Rotate(0, 0, turnAmount);

		// �O���i�E�����j�Ɉړ�
		_rb.velocity = transform.up * _speed;
	}

	// �f�o�b�O�p�ɋO����\��
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
