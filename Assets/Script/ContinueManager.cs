using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueManager : MonoBehaviour
{
    [Header("�R���e�j���[���邽�߂̍Œ�R�C�����i�[")]
    [SerializeField] ContinueCost _cost;
    [SerializeField] Canvas _canvas;

	[SerializeField] Text _minCost; //�Œጸ�̃R�X�g
	[SerializeField] Text _payCost; //�v���C���[�������R�X�g

	int _walletValue;
	bool _isDecision = false;
	//1P, 2P�p�L�[�R�[�h
	KeyCode _keyLeft;
	KeyCode _keyRight;

	private void Start()
	{
		_canvas.gameObject.SetActive(false);
	}

	/// <summary>
	/// �v���C���[�����񂾂�Ăяo����郁�\�b�h
	/// �R���e�j���[�̑���
	/// </summary>
	public void PlayerDead(GameObject player)
    {
		PlayerWalletManager wallet = player.GetComponent<PlayerWalletManager>();
		//Cost�ϐ��̒�`
		int maxCost = wallet.CoinValue();	//Player�̎�����
		int minCost = _cost.Value;			//���݂̃R���e�j���[�ɕK�v�ȋ��z
		_walletValue = minCost;				//

		//�l���R�C�����K�v���z�ȏ゠��Ȃ�R���e�j���[
		if (maxCost >= minCost)
		{
			_isDecision = false;

			//UI�̕\��
			_canvas.gameObject.SetActive(true);
			_minCost.text = minCost.ToString();

			//�R���e�j���[, ���^�C�A�{�^�����������܂Ń��[�v
			while (!_isDecision)
			{
				//���E����Ŏx�����R�X�g�𑝌�
				KeyDownController();
				//�x�����R�X�g�𐧌�������
				_walletValue = Mathf.Clamp(_walletValue, minCost, maxCost);
				//�e�L�X�g���X�V
				_payCost.text = _walletValue.ToString();
			}
		}
		//�l���R�C�����K�v���z�����Ȃ�Q�[���I�[�o�[
		else
		{
			Debug.Log("GameOver�̏������L�q����Ƃ���");
		}
    }

	void KeyDownController()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			_walletValue--;
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			_walletValue++;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_isDecision = true;
		}
	}
}
