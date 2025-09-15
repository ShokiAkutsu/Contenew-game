using UnityEngine;

public interface ISkillEffect
{
    /// <summary>
    /// スキルの効果を記述するメソッド
    /// </summary>
    /// <param name="usePlayerID"></param>
    void Execute(PlayerID usePlayerID);
}
