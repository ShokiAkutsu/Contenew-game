using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
	Animator _anim;
	Rigidbody2D _rb;
	SpriteRenderer _sprite;
	float _horizontal;
	PlayerIDIdentity _id; // PlayerIDを格納するクラス
	
    void Start()
    {
		_anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
		_sprite = GetComponent<SpriteRenderer>();
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

	private void LateUpdate()
	{
		// キャラクターの左右の向きを制御する
		if (_horizontal != 0)
		{
			_sprite.flipX = (_horizontal < 0);
		}

		// アニメーションを制御する
		if (_anim)
		{
			_anim.SetFloat("SpeedX", Mathf.Abs(_rb.velocity.x));
		}
	}
}
