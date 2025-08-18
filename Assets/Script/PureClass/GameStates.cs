using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;

public enum GameState
{
	Playing,	//ゲームをプレイ中
	Pause,		//ポーズ画面中
	Continuw,	//コンテニュー中
	GameOver,	//ゲームオーバー
}

/*

// 4. GameStateManagerクラス
// 全体の状態を管理し、現在の状態の更新を担います。
public class GameStateManager
{
	private Dictionary<GameState, IGameState> states;
	private IGameState currentState;

	// シングルトンパターンを適用して、どこからでもアクセスできるようにする
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
		states.Add(GameState.Paused, new PausedState()); // 仮に存在するとする
		states.Add(GameState.GameOver, new GameOverState()); // 仮に存在するとする

		// 初期状態を設定
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