using UnityEngine;

public interface ISkillEffect
{
    /// <summary>
    /// スキルの効果を記述するメソッド
    /// </summary>
    /// <param name="playerID"></param>
    void Execute(PlayerID playerID);
}
