using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueManager : MonoBehaviour
{
    [Header("�R���e�j���[���邽�߂̍Œ�R�C�����i�[")]
    [SerializeField] ContinueCost _cost;
    [SerializeField] Canvas _canvas;	//�R���e�j���[�L�����o�X��o�^

	[SerializeField] Text _minCost; //�Œጸ�̃R�X�g
	[SerializeField] Text _payCost; //�v���C���[�������R�X�g

	int _payValue;
	bool _isDecision = false;
	//1P, 2P�p�L�[�R�[�h
	PlayerID _activePlayer;

	PlayerWalletManager _wallet;

	private void Start()
	{
		_canvas.gameObject.SetActive(false);
	}

	/// <summary>
	/// �v���C���[�����񂾂�Ăяo����郁�\�b�h
	/// �R���e�j���[�̑���
	/// </summary>
	public IEnumerator PlayerDead(GameObject player)
    {
		//�R���e�j���[����v���C���[���i�[
		_activePlayer = player.GetComponent<PlayerController>().PlayerID;
		//�R�X�g�̊i�[
		_wallet = player.GetComponent<PlayerWalletManager>();
		int maxCost = _wallet.CoinValue();	  //Player�̎��������ő�l
		int minCost = _cost.Value;			 //���݂̃R���e�j���[�ɕK�v�ȋ��z���Œ�l
		_payValue = minCost;				//�K�v���z
		
		//�l���R�C�����K�v���z�ȏ゠��Ȃ�R���e�j���[
		if (maxCost >= minCost)
		{
			yield return StartCoroutine(ContinueProcess(maxCost, minCost));
		}
		//�l���R�C�����K�v���z�����Ȃ�Q�[���I�[�o�[
		else
		{
			Debug.Log("GameOver�̏������L�q����Ƃ���");
			//�V�[���ς��邩
		}

		//�����������������Ƃ�������G�t�F�N�g���o������
	}

	private IEnumerator ContinueProcess(int maxCost, int minCost)
	{
		_isDecision = false;

		//UI�̕\��
		_canvas.gameObject.SetActive(true);
		_minCost.text = minCost.ToString();
		//���삵�Ă���Player�ɍ��킹�āAUI���X�V
		_canvas.GetComponentInChildren<ContinueArrow>().UpdateUI(_activePlayer);
		_canvas.GetComponentInChildren<ActiveUIManager>().UpdateUI(_activePlayer);

		//�R���e�j���[, ���^�C�A�{�^�����������܂Ń��[�v
		while (!_isDecision)
		{
			//���E����Ŏx�����R�X�g�𑝌�
			StartCoroutine(KeyDownControl());
			//�x�����R�X�g�𐧌�������
			_payValue = Mathf.Clamp(_payValue, minCost, maxCost);
			//�e�L�X�g���X�V
			_payCost.text = _payValue.ToString();
			// ������1�t���[���ҋ@���AUnity�ɐ����߂��B
			yield return null;
		}

		//�R���e�j���[�̍Œ�R�X�g���X�V
		_cost.Update(_payValue);
		//���z�̒���payValue���炷
		_wallet.SetWallet(-_payValue);
		//UI���\���ɂ���
		_canvas.gameObject.SetActive(false);
	}

	/// <summary>
	/// �x�����R�C�����L�[�ő���������
	/// </summary>
	/// <returns></returns>
	IEnumerator KeyDownControl()
	{
		if (Input.GetKeyDown(InputMove.GetLeftKey(_activePlayer)))
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

		yield return null;
	}
}
