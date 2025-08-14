using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
	[Header("コインの枚数・価値")]
	[SerializeField] int _value = 1;
	public int Value => _value;

	/*
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }
	}
	*/
}
