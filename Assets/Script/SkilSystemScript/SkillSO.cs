using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Skill", menuName ="Skills/Skill Data")]
public class SkillSO : ScriptableObject
{
	[Header("基本情報")]
	[SerializeField] string _skillName;          // スキル名（デバッグや識別用）
	[SerializeField] int _cost;                  // 発動コスト
	[SerializeField] Sprite _icon;               // UI表示用アイコン
	[Header("スキル効果")]
	[SerializeField] GameObject _skillEffectPrefab; // 効果実行用のプレハブ

	public string SkillName => _skillName;
	public int Cost => _cost;
	public Sprite Icon => _icon;
	public GameObject SkillEffectPrefab => _skillEffectPrefab;
}
