using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickDirector : MonoBehaviour
{
	PlayerDeadManager _dead;
	PlayerIDIdentity _id;
	[SerializeField] bool _gotMode = false;
	[SerializeField] float _gotTime = 3f;
	float _timer = -1; // �f�o�b�O�p�����l

	void Start()
	{
		_dead = GameObject.FindObjectOfType<PlayerDeadManager>();
		_id = GetComponent<PlayerIDIdentity>();
	}

	private void Update()
	{
		if (_gotMode && _timer != -1)
		{
			_timer += Time.deltaTime;

			if(_gotTime <  _timer)
			{
				_gotMode = false;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!_gotMode && collision.gameObject.tag == "Gimmick")
		{
			_timer = 0; // �f�o�b�O�p���l��������
			_gotMode = true;
			Debug.Log("��Q���Ɠ�����܂���");
			StartCoroutine(_dead.IsContinue(_id.PlayerID));
		}
	}
}
