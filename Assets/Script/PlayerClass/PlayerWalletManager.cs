using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalletManager : MonoBehaviour
{
	[SerializeField] CoinWallet _wallet;
	CoinTextManager _textManager;
	PlayerIDIdentity _id;

	public int CoinValue()
	{
		return _wallet.Coins;
	}

	private void Start()
	{
		_textManager = GameObject.FindObjectOfType<CoinTextManager>();
		_id = GetComponent<PlayerIDIdentity>();
		//初期設定の所持金がUIに反映されるようにする
		_textManager.UpdateUI(_id.PlayerID, _wallet.Coins);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Coin")
		{
			CoinManager coin = collision.GetComponent<CoinManager>();

			SetWallet(coin.Value);

			Destroy(collision.gameObject);
		}
	}

	/// <summary>
	/// 所持金の増減とUIの更新を行うメソッド
	/// </summary>
	/// <param name="value"></param>
	public void SetWallet(int value)
	{
		//コインの価値を反映
		_wallet.Collect(value);
		//コインのUI更新
		_textManager.UpdateUI(_id.PlayerID, _wallet.Coins);
	}
}
