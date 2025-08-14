using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
	[SerializeField] InputMoveSetting _inputSetting;
	Rigidbody2D _rb;
	float _horizontal;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
		//_inputSetting = new InputMoveSetting();
    }

	private void Update()
	{
		//���ړ��̏�����
		_horizontal = 0;

		//Inspector�Őݒ肵���L�[�������ꂽ��A_horizontal�ɒl������
		if (Input.GetKey(_inputSetting.Left))
		{
			_horizontal = -1;
		}
		else if (Input.GetKey(_inputSetting.Right))
		{
			_horizontal = 1;
		}
	}

	private void FixedUpdate()
	{
		_rb.velocity = new Vector2(_horizontal * _moveSpeed, _rb.velocity.y);
	}
}
