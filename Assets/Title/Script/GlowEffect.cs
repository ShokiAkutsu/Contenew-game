using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowEffect : MonoBehaviour
{
	[SerializeField] KeyCode _playKey;
	SpriteRenderer spriteRenderer;
	Color _color;
	[SerializeField] float _defaultAlpha = 0.8f; // キーが押されていない状態の値
	float _maxAlpha = 1f;
	bool _active = false;
	public bool Active => _active;

	private void Start()
	{
		// このゲームオブジェクトにアタッチされているSprite Rendererコンポーネントを取得
		spriteRenderer = GetComponent<SpriteRenderer>();
		// 現在の色を取得
		_color = spriteRenderer.color;
	}

	private void Update()
	{
		// スペースキーが押された瞬間
		if (Input.GetKeyDown(_playKey))
		{
			// アルファ値を最大に設定
			_color.a = _maxAlpha;
			_active = true;
		}
		// スペースキーが離された瞬間
		if (Input.GetKeyUp(_playKey))
		{
			// アルファ値を0.5（元の値、または任意の値）に戻す
			_color.a = _defaultAlpha;
			_active = false;
		}
		// アルファ値を反映
		spriteRenderer.color = _color;
	}
}
