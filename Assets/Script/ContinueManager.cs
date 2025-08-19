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

	int _payValue;
	bool _isDecision = false;
	//1P, 2P�p�L�[�R�[�h
	PlayerID _activePlayer;

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
		//�R���e�j���[����v���C���[���i�[
		_activePlayer = player.GetComponent<PlayerController>().PlayerID;
		//�R�X�g�̊i�[
		PlayerWalletManager wallet = player.GetComponent<PlayerWalletManager>();
		int maxCost = wallet.CoinValue();	//Player�̎�����
		int minCost = _cost.Value;			//���݂̃R���e�j���[�ɕK�v�ȋ��z
		_payValue = minCost;				//�K�v���z
		
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
				KeyDownControl();
				//�x�����R�X�g�𐧌�������
				_payValue = Mathf.Clamp(_payValue, minCost, maxCost);
				//�e�L�X�g���X�V
				_payCost.text = _payValue.ToString();
			}
		}
		//�l���R�C�����K�v���z�����Ȃ�Q�[���I�[�o�[
		else
		{
			Debug.Log("GameOver�̏������L�q����Ƃ���");
		}
    }

	void KeyDownControl()
	{
		if(Input.GetKeyDown(InputMove.GetLeftKey(_activePlayer)))
		{
			_payValue--;
		}
		if (Input.GetKeyDown(InputMove.GetRightKey(_activePlayer)))
		{
			_payValue++;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_isDecision = true;
		}
	}
}
