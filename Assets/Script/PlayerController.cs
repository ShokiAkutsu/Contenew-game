using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
	Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		
	}

	private void FixedUpdate()
	{
		// "Horizontal" 入力（-1, 0, 1）を取得
		float horizontal = Input.GetAxisRaw("Horizontal");

		// Rigidbodyの速度を直接設定
		// Y軸の速度は現在のものを維持することで、重力やジャンプの動きを妨げないようにします
		_rb.velocity = new Vector2(horizontal * _moveSpeed, _rb.velocity.y);
	}
}
