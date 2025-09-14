using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillDeckManager : MonoBehaviour
{
    [SerializeField] List<SkillSO> _deck;

    SkillSO _leftSkill;
    SkillSO _centerSkill;
    SkillSO _rightSkill;

	private void Awake()
	{
        // ���\�b�h�̎g���������������Ȃ�A���ڋL�q����
		ShuffleDeck();
	}

	private void Start()
    {
        // ������D���i�[
        _leftSkill = DrawDeck();
        _centerSkill = DrawDeck();
        _rightSkill = DrawDeck();
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
    public bool TryActivate(SkillSO skill, PlayerID player)
    {
        if(skill == null && skill.Cost < 0)
        {
            return false;
        }

		// ����������R�X�g����������(Player�̏��������Q�Ƃ��鏑������������)

		ExecuteSkillEffect(skill, player); // �X�L���𔭓�����

		_deck.Add(skill); // �X�L�����ʔ�����A�R�D�̌��Ɋi�[

		// �󂢂���D�ɃX�L�����[(���Ԃ�����΂P�s�ɂ�����)
		if (skill == _leftSkill)
        {
			_leftSkill = DrawDeck();
		}	
		else if (skill == _centerSkill)
        {
			_centerSkill = DrawDeck();
		}	
		else if (skill == _rightSkill)
        {
            _rightSkill = DrawDeck();
        }

		return true;
    }

	/// <summary>
	/// ���ʔ��������i���V���v���Ɂj
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
