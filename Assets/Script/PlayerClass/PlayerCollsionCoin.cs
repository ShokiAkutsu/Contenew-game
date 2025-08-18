using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsionCoin : MonoBehaviour
{
	[SerializeField] CoinWallet _wallet;
	CoinTextManager _textManager;

	private void Start()
	{
		_textManager = GameObject.FindObjectOfType<CoinTextManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Coin")
		{
			CoinManager coin = collision.GetComponent<CoinManager>();
			//�R�C���̉��l�𔽉f
			_wallet.Collect(coin.Value);
			//�R�C����UI�X�V
			_textManager.UpdateUI(_wallet.PlayerID, _wallet.Coins);
			Destroy(collision.gameObject);
		}
	}
}
