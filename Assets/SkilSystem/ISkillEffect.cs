using UnityEngine;

public interface ISkillEffect
{
    /// <summary>
    /// �X�L���̌��ʂ��L�q���郁�\�b�h
    /// </summary>
    /// <param name="usePlayerID"></param>
    void Execute(PlayerID usePlayerID);
}
