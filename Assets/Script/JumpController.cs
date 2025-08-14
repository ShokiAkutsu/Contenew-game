using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
	[SerializeField] float _jumpForce = 3f;
	Rigidbody2D _rb;

	bool _isGround = false;

	// Start is called before the first frame update
	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		//‚È‚º‚©Jump‚ªŽg‚¦‚È‚¢‚½‚ß
		if (Input.GetKeyDown(KeyCode.W) && _isGround)
		{
			_rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
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
