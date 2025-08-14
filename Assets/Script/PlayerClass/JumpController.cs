using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
	[SerializeField] float _jumpForce = 3f;
	[SerializeField] InputJumpSetting _inputSetting;
	[SerializeField] float _fallMultiplier = 3f;
	Rigidbody2D _rb;
	//�ݒu����
	bool _isGround = false;

	// Start is called before the first frame update
	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(_inputSetting.Jump) && _isGround)
		{
			_rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
		}
	}

	void FixedUpdate()
	{
		// �������~���iverticalVelocity�����̒l�j�ł���΁A�d�͂���苭������
		if (_rb.velocity.y < 0)
		{
			// AddForce�ŉ������ɗ͂�������
			_rb.AddForce(Vector2.up * Physics2D.gravity.y * _fallMultiplier, ForceMode2D.Force);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			_isGround = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			_isGround = false;
		}
	}
}
