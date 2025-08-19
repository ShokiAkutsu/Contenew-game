using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public enum GameState
{
	Playing,	//ゲームをプレイ中
	//Paused,		//ポーズ画面中(現在デバッグ用, 追加出来たらやる)
	Continue,	//コンテニュー中
	GameOver,	//ゲームオーバー
}