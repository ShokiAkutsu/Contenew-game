using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Skill", menuName ="Skills/Skill Data")]
public class SkillSO : ScriptableObject
{
	[Header("��{���")]
	[SerializeField] SkillType _Type;
	[SerializeField] string _skillName;          // �X�L�����i�f�o�b�O�⎯�ʗp�j
	[SerializeField] int _cost;                  // �����R�X�g
	[SerializeField] Sprite _icon;               // UI�\���p�A�C�R��
	[Header("�X�L������")]
	[SerializeField] GameObject _skillEffectPrefab; // ���ʎ��s�p�̃v���n�u

	public SkillType Type => _Type; 
	public string SkillName => _skillName;
	public int Cost => _cost;
	public Sprite Icon => _icon;
	public GameObject SkillEffectPrefab => _skillEffectPrefab;
}

public enum SkillType
{
	Gimmick,
	Chebge,
}
