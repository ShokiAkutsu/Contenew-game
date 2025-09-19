using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseManager : MonoBehaviour
{
	// ポーズイベントと再開イベントを定義
	public static event Action OnPause;
	public static event Action OnResume;

	// ゲームがポーズ中かどうかを追跡する変数
	public bool isPaused { get; private set; } = false;


	/// <summary>
	/// ポーズとコンティニューを切り替えるメソッド
	/// </summary>
	public void Switching()
	{
		// 現在の状態を反転させる
		isPaused = !isPaused;

		if (isPaused)
		{
			OnPause?.Invoke();
		}
		else
		{
			OnResume?.Invoke();
		}
	}

	public void On()
	{
		OnPause?.Invoke();
	}

	public void Off()
	{
		OnResume?.Invoke();
	}
}
