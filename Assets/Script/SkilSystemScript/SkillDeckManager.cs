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
        // メソッドの使い道がここだけなら、直接記述する
		ShuffleDeck();
	}

	private void Start()
    {
        // 初期手札を格納
        _leftSkill = DrawDeck();
        _centerSkill = DrawDeck();
        _rightSkill = DrawDeck();
    }

    /// <summary>
    /// 表示するスキルを山札の先頭スキルを補充するメソッド
    /// </summary>
    SkillSO DrawDeck()
    {
		if (_deck.Count == 0)
		{
			Debug.LogWarning("山札が空です！");
			return null;
		}

		SkillSO newSkill = _deck[0]; // 先頭にあるスキルを手札の候補にする
        _deck.RemoveAt(0);           // 山札の先頭のスキルを排除する
        return newSkill;
    }

	/// <summary>
	/// 所持金がコスト以上あるならスキルを発動し、
	/// 山札から手札を補充するメソッド
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

		// 所持金からコストを差し引く(Playerの所持金を参照する書き方をしたい)

		ExecuteSkillEffect(skill, player); // スキルを発動する

		_deck.Add(skill); // スキル効果発動後、山札の後ろに格納

		// 空いた手札にスキルを補充(時間があれば１行にしたい)
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
	/// 効果発動処理（よりシンプルに）
	/// </summary>
	/// <param name="skill"></param>
	/// <param name="player"></param>
	private void ExecuteSkillEffect(SkillSO skill, PlayerID player)
	{
		if (skill.SkillEffectPrefab == null) return;

		// プレハブから直接インターフェースを取得して実行
		ISkillEffect effect = skill.SkillEffectPrefab.GetComponent<ISkillEffect>();
		if (effect != null)
		{
			effect.Execute(player);
		}

		// エフェクトの視覚表現用にインスタンス化（必要なら）
		GameObject visualEffect = Instantiate(skill.SkillEffectPrefab);
		Destroy(visualEffect, 2f);
	}

	/// <summary>
	/// リストにあるスキルの順番を入れ替える
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
