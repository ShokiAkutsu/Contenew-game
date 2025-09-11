using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseManager : MonoBehaviour
{
	// シングルトンインスタンス
	public static PauseManager Instance { get; private set; }

	// ポーズイベントと再開イベントを定義
	public static event Action OnPause;
	public static event Action OnResume;

	// ゲームがポーズ中かどうかを追跡する変数
	public bool isPaused { get; private set; } = false;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Update()
	{
		// ESC キーが押されたら一時停止・再開を切り替える(0819：デバッグ用)
		// コンテニュー中なら反応しないを付け加えたらいい感じかも
		if (Input.GetButtonDown("Cancel"))
		{
			Debug.Log("スイッチ中");
			Switching();
		}
	}

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
