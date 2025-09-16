using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillDeckManager : MonoBehaviour
{
	// スキルの山札
    [SerializeField] List<SkillSO> _deck;
	// スキルの手札(別スクリプトで管理予定)
	OpenSkillManager _openSkillManager;
	Dictionary<SkillPosition, SkillSO> _openSkill = new Dictionary<SkillPosition, SkillSO>();
	// 各プレイヤーの所持金参照
	PlayerWalletManager _wallet1P;
	PlayerWalletManager _wallet2P;

	private void Awake()
	{
        // メソッドの使い道がここだけなら、直接記述する
		ShuffleDeck();
		// 手札管理マネージャー
		_openSkillManager = GameObject.FindFirstObjectByType<OpenSkillManager>();

		// 初期手札を格納
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
    /// 表示するスキルを山札の先頭から補充するメソッド
    /// </summary>
    void DrawDeck(SkillPosition skillPos)
    {
		if (_deck.Count == 0)
		{
			Debug.LogWarning("山札が空です！");
			return;
		}

		SkillSO newSkill = _deck[0]; // 先頭にあるスキルを手札の候補にする
		_openSkill[skillPos] = newSkill; // 空いた手札にスキルを補充
		_deck.RemoveAt(0);           // 山札の先頭のスキルを排除する

		// 新しいスキルのアイコンとUIの更新
		_openSkillManager.SkillUpdate(newSkill, skillPos);
    }

	/// <summary>
	/// 所持金がコスト以上あるならスキルを発動させる
	/// (ここだけ手札のスキル処理なので、分けてもいいかもしれない)
	/// </summary>
	/// <param name="skill"></param>
	/// <param name="player"></param>
	/// <returns></returns>
    public void TryActivate(PlayerID player, SkillPosition skillPos)
    {
		SkillSO skill = _openSkill[skillPos]; // 対応位置にあるスキルを格納

		if (skill == null) return;

		// 所持金からコストを差し引く
		if(player == PlayerID.Player_1P)
		{
			// コスト未満なら終了
			if (_wallet1P.CoinValue() - skill.Cost < 0) return;

			_wallet1P.SetWallet(-skill.Cost);
		}
		else
		{
			// コスト未満なら終了
			if (_wallet2P.CoinValue() - skill.Cost < 0) return;

			_wallet2P.SetWallet(-skill.Cost);
		}

		ExecuteSkillEffect(skill, player); // スキルを発動する

		_deck.Add(skill); // スキル効果発動後、山札の後ろに格納

		DrawDeck(skillPos);
	}

	/// <summary>
	/// 効果発動処理メソッド
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
