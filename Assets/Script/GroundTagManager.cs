using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundTagManager : MonoBehaviour
{
	Dictionary<Rigidbody2D, PhysicsState> _groundStates = new Dictionary<Rigidbody2D, PhysicsState>();
	//List<Rigidbody2D> _groundRb = new List<Rigidbody2D>();

	private struct PhysicsState
	{
		public Vector3 _velocity;
		public float _angularVelocity;
	}

	private void OnEnable()
	{
		PauseManager.OnPause += Stopping;
		PauseManager.OnResume += Starting;
	}

	private void OnDisable()
	{
		PauseManager.OnPause -= Stopping;
		PauseManager.OnResume -= Starting;
	}

	public void Stopping()
	{
		//���ݐ�������Ă��鑫���S�Ď擾����
		GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");

		foreach (GameObject obj in grounds)
		{
			Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

			if (rb == null) continue;

			PhysicsState state = new PhysicsState   // ����̏�Ԃ�ۑ����Ă���
			{
				_velocity = rb.velocity,
				_angularVelocity = rb.angularVelocity
			};
			
			_groundStates[rb] = state;  // Dictionary�Ɋi�[			
			rb.Sleep();				�@ //�������~�߂�
		}
	}

	public void Starting()
	{
		foreach (var kvp in _groundStates)
		{
			Rigidbody2D rb = kvp.Key;

			if (rb == null) continue;

			rb.WakeUp();	//�������ĊJ

			PhysicsState state = kvp.Value;     // ����̏�Ԃ�n��

			rb.velocity = state._velocity;					// ����̏�Ԃ����ɖ߂�
			rb.angularVelocity = state._angularVelocity;
		}

		_groundStates.Clear();  // Dictionary��������������
	}
}
