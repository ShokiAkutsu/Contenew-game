using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillDeckManager : MonoBehaviour
{
	// �X�L���̎R�D
    [SerializeField] List<SkillSO> _deck;
	// �X�L���̎�D(�ʃX�N���v�g�ŊǗ��\��)
	OpenSkillManager _openSkillManager;
	Dictionary<SkillPosition, SkillSO> _openSkill = new Dictionary<SkillPosition, SkillSO>();
	// �e�v���C���[�̏������Q��
	PlayerWalletManager _wallet1P;
	PlayerWalletManager _wallet2P;

	private void Awake()
	{
        // ���\�b�h�̎g���������������Ȃ�A���ڋL�q����
		ShuffleDeck();
		// ��D�Ǘ��}�l�[�W���[
		_openSkillManager = GameObject.FindFirstObjectByType<OpenSkillManager>();

		// ������D���i�[
		DrawDeck(SkillPosition.Left);
		DrawDeck(SkillPosition.Center);
		DrawDeck(SkillPosition.Right);
	}

	private void Start()
	{
		PlayerIDManager playerIDManager = GameObject.FindObjectOfType<PlayerIDManager>();
		_wallet1P = playerIDManager.GetPlayerComponent<PlayerWalletManager>(PlayerID.Player_1P);
		_wallet2P = playerIDManager.GetPlayerComponent<PlayerWalletManager>(PlayerID.Player_2P);
	}

    /// <summary>
    /// �\������X�L�����R�D�̐擪�����[���郁�\�b�h
    /// </summary>
    void DrawDeck(SkillPosition skillPos)
    {
		if (_deck.Count == 0)
		{
			Debug.LogWarning("�R�D����ł��I");
			return;
		}

		SkillSO newSkill = _deck[0]; // �擪�ɂ���X�L������D�̌��ɂ���
		_openSkill[skillPos] = newSkill; // �󂢂���D�ɃX�L�����[
		_deck.RemoveAt(0);           // �R�D�̐擪�̃X�L����r������

		// �V�����X�L���̃A�C�R����UI�̍X�V
		_openSkillManager.SkillUpdate(newSkill, skillPos);
    }

	/// <summary>
	/// ���������R�X�g�ȏ゠��Ȃ�X�L���𔭓�������
	/// (����������D�̃X�L�������Ȃ̂ŁA�����Ă�������������Ȃ�)
	/// </summary>
	/// <param name="skill"></param>
	/// <param name="player"></param>
	/// <returns></returns>
    public void TryActivate(PlayerID player, SkillPosition skillPos)
    {
		SkillSO skill = _openSkill[skillPos]; // �Ή��ʒu�ɂ���X�L�����i�[

		if (skill == null) return;

		// ����������R�X�g����������
		if(player == PlayerID.Player_1P)
		{
			// �R�X�g�����Ȃ�I��
			if (_wallet1P.CoinValue() - skill.Cost < 0) return;

			_wallet1P.SetWallet(-skill.Cost);
		}
		else
		{
			// �R�X�g�����Ȃ�I��
			if (_wallet2P.CoinValue() - skill.Cost < 0) return;

			_wallet2P.SetWallet(-skill.Cost);
		}

		ExecuteSkillEffect(skill, player); // �X�L���𔭓�����

		_deck.Add(skill); // �X�L�����ʔ�����A�R�D�̌��Ɋi�[

		DrawDeck(skillPos);
	}

	/// <summary>
	/// ���ʔ����������\�b�h
	/// </summary>
	/// <param name="skill"></param>
	/// <param name="player"></param>
	private void ExecuteSkillEffect(SkillSO skill, PlayerID player)
	{
		if (skill.SkillEffectPrefab == null) return;

		// �v���n�u���璼�ڃC���^�[�t�F�[�X���擾���Ď��s
		ISkillEffect effect = skill.SkillEffectPrefab.GetComponent<ISkillEffect>();
		if (effect != null)
		{
			effect.Execute(player);
		}

		// �G�t�F�N�g�̎��o�\���p�ɃC���X�^���X���i�K�v�Ȃ�j
		GameObject visualEffect = Instantiate(skill.SkillEffectPrefab);
		Destroy(visualEffect, 2f);
	}

	/// <summary>
	/// ���X�g�ɂ���X�L���̏��Ԃ����ւ���
	/// </summary>
	void ShuffleDeck()
    {
		for (int i = _deck.Count - 1; i > 0; i--)
		{
			int randomIndex = Random.Range(0, i + 1);
			SkillSO skill = _deck[i];
			_deck[i] = _deck[randomIndex];
			_deck[randomIndex] = skill;
		}
	}
}
