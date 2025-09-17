using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverEffect : MonoBehaviour
{
	[SerializeField] GameObject _circle;
	[SerializeField] float _maxScale = 40f;
	[SerializeField] float _duration = 1.0f;
	float _timer;
	SpriteRenderer _render;

	private void Start()
	{
		_render = _circle.GetComponent<SpriteRenderer>();
	}

	public void StartEffect(Vector3 playerPos, PlayerID target)
	{
		StartCoroutine(Transition(playerPos, target));
	}

	private IEnumerator Transition(Vector3 worldPos, PlayerID target)
	{
		// ワールド座標に移動
		_circle.transform.position = worldPos;

		// 初期化
		_circle.transform.localScale = Vector3.zero;
		_circle.SetActive(true);

		Color color = target == PlayerID.Player_1P ? Color.red : Color.blue; // IDで色変化

		_render.color = color; //色を登録

		while (_timer < _duration)
		{
			_timer += Time.deltaTime;

			float scale = Mathf.Lerp(0, _maxScale, _timer / _duration); // 時間に応じてscaleを大きくする
			_circle.transform.localScale = new Vector3(scale, scale, 1); // 円を大きくする
			yield return null;
		}

		// 色を保存
		PlayerPrefs.SetFloat("ColorR", color.r);
		PlayerPrefs.SetFloat("ColorG", color.g);
		PlayerPrefs.SetFloat("ColorB", color.b);
		// Player名前保存
		string text = target == PlayerID.Player_1P ? "Winner Player1" : "Winner Player2";
		PlayerPrefs.SetString("Winner", text);

		SceneManager.LoadScene(2);
	}
}