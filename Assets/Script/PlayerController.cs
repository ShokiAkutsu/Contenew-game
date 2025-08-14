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
		// "Horizontal" ���́i-1, 0, 1�j���擾
		float horizontal = Input.GetAxisRaw("Horizontal");

		// Rigidbody�̑��x�𒼐ڐݒ�
		// Y���̑��x�͌��݂̂��̂��ێ����邱�ƂŁA�d�͂�W�����v�̓�����W���Ȃ��悤�ɂ��܂�
		_rb.velocity = new Vector2(horizontal * _moveSpeed, _rb.velocity.y);
	}
}
