using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadManager : MonoBehaviour
{
	PauseManager _pause;
	ContinueManager _continue;

	private void Start()
	{
		_pause = GameObject.FindObjectOfType<PauseManager>();
		_continue = GameObject.FindObjectOfType<ContinueManager>();
	}

	public IEnumerator IsContinue(GameObject player)
    {
		//ゲームで動いていた物体を停止
		_pause.On();
		//コンテニューの処理が終わるまで待機
		yield return StartCoroutine(_continue.PlayerDead(player));

		Debug.Log("コンテニューの終了");
		//ゲームの再開
		_pause.Off();
    }
}
