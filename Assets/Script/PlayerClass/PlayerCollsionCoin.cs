using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsionCoin : MonoBehaviour
{
	[SerializeField] CoinWallet _wallet;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Coin")
		{
			CoinManager coin = collision.GetComponent<CoinManager>();
			_wallet.Collect(coin.Value);
			Destroy(collision.gameObject);
		}
	}
}
