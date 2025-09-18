using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{
	[SerializeField] float _nonActionTime = 10f;
	float _timer;

	void Update()
	{
		_timer += Time.deltaTime;

		// 両方がSとKを押した場合のみゲーム開始
		if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.K))
		{
			SceneManager.LoadScene(1);
		}
		// SpaceかタイムオーバーならTitleへ
		else if(Input.GetKey(KeyCode.Space) || _timer > _nonActionTime)
		{
			SceneManager.LoadScene(0);
		}
	}
}
