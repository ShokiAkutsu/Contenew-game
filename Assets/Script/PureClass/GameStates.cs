using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public enum GameState
{
	Playing,	//�Q�[�����v���C��
	//Paused,		//�|�[�Y��ʒ�(���݃f�o�b�O�p, �ǉ��o��������)
	Continue,	//�R���e�j���[��
	GameOver,	//�Q�[���I�[�o�[
}