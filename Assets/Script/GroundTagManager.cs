using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GroundTagManager : MonoBehaviour
{
	// ����̏�Ԃ��i�[
	Dictionary<Rigidbody2D, PhysicsState> _groundStates = new Dictionary<Rigidbody2D, PhysicsState>();

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
		// Linq���g�p����ۑ� �׋��̂��߂ɃR�����g
		GameObject.FindGameObjectsWithTag("Ground")		// Ground�^�O��GameObject��S�擾
		.Select(obj => obj.GetComponent<Rigidbody2D>()) // RigidBody2D���擾����{�I���}�Ԃ�
		.Where(rb => rb != null)						// rb��null�`�F�b�N {Where��bool�ł�����}
		.ToList()										// ���X�g�� {true�Ȃ烊�X�g��}
		.ForEach(rb =>									// �������~�߂邽�߂�foreach���s�� {���X�g���܂킷}
		{
			_groundStates[rb] = new PhysicsState
			{
				_velocity = rb.velocity, 
				_angularVelocity = rb.angularVelocity
			};
			rb.Sleep();// �������~
		});
	}

	public void Starting()
	{
		// �쐬���Ă���X�e�[�^�X����ɂ���
		_groundStates
		.Where(kvp => kvp.Key != null)					// null�`�F�b�N
		.ToList()										// ���X�g������
		.ForEach(kvp =>									// ���X�g���܂킷
		{
			Rigidbody2D rb = kvp.Key;
			rb.WakeUp(); // �������ĊJ

			PhysicsState state = kvp.Value; // ����̏�Ԃ�n��
			// ����̏�Ԃ����ɖ߂�
			rb.velocity = state._velocity;  
			rb.angularVelocity = state._angularVelocity;
		});

		_groundStates.Clear(); // Dictionary��������
	}
}
