using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
	Rigidbody2D _rb;
	float _horizontal;
	PlayerIDIdentity _id; // PlayerID‚ðŠi”[‚·‚éƒNƒ‰ƒX
	
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
		_id = GetComponent<PlayerIDIdentity>();
    }

	private void Update()
	{
		_horizontal = InputMove.GetHorizontalAxis(_id.PlayerID);
	}

	private void FixedUpdate()
	{
		_rb.velocity = new Vector2(_horizontal * _moveSpeed, _rb.velocity.y);
	}
}
