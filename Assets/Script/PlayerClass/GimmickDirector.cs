using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickDirector : MonoBehaviour
{
	PlayerDeadManager _dead;
	[SerializeField] bool _gotMode = false;

	void Start()
	{
		_dead = GameObject.FindObjectOfType<PlayerDeadManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!_gotMode && collision.gameObject.tag == "Gimmick")
		{
			Debug.Log("è·äQï®Ç∆ìñÇΩÇËÇ‹ÇµÇΩ");
			StartCoroutine(_dead.IsContinue(this.gameObject));
		}
	}
}
