using UnityEngine;

public interface ISkillEffect
{
    /// <summary>
    /// �X�L���̌��ʂ��L�q���郁�\�b�h
    /// </summary>
    /// <param name="playerID"></param>
    void Execute(PlayerID playerID);
}
