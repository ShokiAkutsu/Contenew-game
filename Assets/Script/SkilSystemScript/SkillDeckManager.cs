using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillDeckManager : MonoBehaviour
{
	// �X�L���̎R�D
    [SerializeField] List<SkillSO> _deck;
	// �X�L���̎�D
	Dictionary<SkillPosition, SkillSO> _openSkill = new Dictionary<SkillPosition, SkillSO>();
	// �e�v���C���[�̏������Q��
	PlayerWalletManager _wallet1P;
	PlayerWalletManager _wallet2P;

	private void Awake()
	{
        // ���\�b�h�̎g���������������Ȃ�A���ڋL�q����
		ShuffleDeck();
	}

	private void Start()
    {
		PlayerIDManager playerIDManager = GameObject.FindObjectOfType<PlayerIDManager>();
		_wallet1P = playerIDManager.GetPlayerComponent<PlayerWalletManager>(PlayerID.Player_1P);
		_wallet2P = playerIDManager.GetPlayerComponent<PlayerWalletManager>(PlayerID.Player_2P);

		// ������D���i�[
		_openSkill[SkillPosition.Left] = DrawDeck();
		_openSkill[SkillPosition.Center] = DrawDeck();
		_openSkill[SkillPosition.Right] = DrawDeck();
    }

    /// <summary>
    /// �\������X�L�����R�D�̐擪�X�L�����[���郁�\�b�h
    /// </summary>
    SkillSO DrawDeck()
    {
		if (_deck.Count == 0)
		{
			Debug.LogWarning("�R�D����ł��I");
			return null;
		}

		SkillSO newSkill = _deck[0]; // �擪�ɂ���X�L������D�̌��ɂ���
        _deck.RemoveAt(0);           // �R�D�̐擪�̃X�L����r������
        return newSkill;
    }

	/// <summary>
	/// ���������R�X�g�ȏ゠��Ȃ�X�L���𔭓����A
	/// �R�D�����D���[���郁�\�b�h
	/// </summary>
	/// <param name="skill"></param>
	/// <param name="player"></param>
	/// <returns></returns>
    public void TryActivate(PlayerID player, SkillPosition skillPos)
    {
		SkillSO skill = _openSkill[skillPos]; // �Ή��ʒu�ɂ���X�L�����i�[

		// �R�X�g�����Ȃ�I��
        if(skill == null && skill.Cost < 0)	return;

		// ����������R�X�g����������
		if(player == PlayerID.Player_1P)
		{
			_wallet1P.SetWallet(-skill.Cost);
		}
		else
		{
			_wallet2P.SetWallet(-skill.Cost);
		}

		ExecuteSkillEffect(skill, player); // �X�L���𔭓�����

		_deck.Add(skill); // �X�L�����ʔ�����A�R�D�̌��Ɋi�[

		_openSkill[skillPos] = DrawDeck(); // �󂢂���D�ɃX�L�����[
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
