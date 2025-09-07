using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] PlayerID _playerID;
    [SerializeField] float _moveSpeed = 3f;
	Rigidbody2D _rb;
	float _horizontal;
	public PlayerID PlayerID => _playerID;
	
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

	private void Update()
	{
		_horizontal = InputMove.GetHorizontalAxis(_playerID);
	}

	private void FixedUpdate()
	{
		_rb.velocity = new Vector2(_horizontal * _moveSpeed, _rb.velocity.y);
	}
}
