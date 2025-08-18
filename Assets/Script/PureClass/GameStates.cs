using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;

public enum GameState
{
	Playing,	//�Q�[�����v���C��
	Pause,		//�|�[�Y��ʒ�
	Continuw,	//�R���e�j���[��
	GameOver,	//�Q�[���I�[�o�[
}

/*

// 4. GameStateManager�N���X
// �S�̂̏�Ԃ��Ǘ����A���݂̏�Ԃ̍X�V��S���܂��B
public class GameStateManager
{
	private Dictionary<GameState, IGameState> states;
	private IGameState currentState;

	// �V���O���g���p�^�[����K�p���āA�ǂ�����ł��A�N�Z�X�ł���悤�ɂ���
	private static GameStateManager instance;
	public static GameStateManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameStateManager();
			}
			return instance;
		}
	}

	private GameStateManager()
	{
		states = new Dictionary<GameState, IGameState>();
		states.Add(GameState.Title, new TitleState());
		states.Add(GameState.Playing, new PlayingState());
		states.Add(GameState.Paused, new PausedState()); // ���ɑ��݂���Ƃ���
		states.Add(GameState.GameOver, new GameOverState()); // ���ɑ��݂���Ƃ���

		// ������Ԃ�ݒ�
		currentState = states[GameState.Title];
		currentState.EnterState();
	}

	public void ChangeState(GameState newStateEnum)
	{
		if (currentState != null)
		{
			currentState.ExitState();
		}

		currentState = states[newStateEnum];
		currentState.EnterState();
	}

	public void UpdateCurrentState()
	{
		if (currentState != null)
		{
			currentState.Update();
		}
	}
}
*/