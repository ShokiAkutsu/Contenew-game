using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickDirector : MonoBehaviour
{
	PlayerDeadManager _dead;
	PlayerIDIdentity _id;
	[SerializeField] bool _gotMode = false;
	[SerializeField] float _gotTime = 3f;
	float _timer = -1; // デバッグ用初期値

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
			_timer = 0; // デバッグ用数値を初期化
			_gotMode = true;
			Debug.Log("障害物と当たりました");
			StartCoroutine(_dead.IsContinue(_id.PlayerID));
		}
	}
}
