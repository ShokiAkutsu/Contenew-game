using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalletManager : MonoBehaviour
{
	[SerializeField] CoinWallet _wallet;
	CoinTextManager _textManager;
	PlayerIDIdentity _id;
	AudioSource _audio;
	[SerializeField] AudioClip _clip;

	public int CoinValue()
	{
		return _wallet.Coins;
	}

	private void Start()
	{
		_textManager = GameObject.FindObjectOfType<CoinTextManager>();
		_id = GetComponent<PlayerIDIdentity>();
		_audio = GetComponent<AudioSource>();
		//�����ݒ�̏�������UI�ɔ��f�����悤�ɂ���
		_textManager.UpdateUI(_id.PlayerID, _wallet.Coins);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Coin")
		{
			CoinManager coin = collision.GetComponent<CoinManager>();

			_audio.PlayOneShot(_clip);

			SetWallet(coin.Value);

			Destroy(collision.gameObject);
		}
	}

	/// <summary>
	/// �������̑�����UI�̍X�V���s�����\�b�h
	/// </summary>
	/// <param name="value"></param>
	public void SetWallet(int value)
	{
		//�R�C���̉��l�𔽉f
		_wallet.Collect(value);
		//�R�C����UI�X�V
		_textManager.UpdateUI(_id.PlayerID, _wallet.Coins);
	}
}
