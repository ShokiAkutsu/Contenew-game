using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect2 : MonoBehaviour
{
	// フェードアウトにかける時間
	[SerializeField] float _fadeOutTime = 1.0f;

	// フェードアウト処理を開始するメソッド
	public void StartFadeOut()
	{
		StartCoroutine(FadeOutCoroutine());
	}

	// 徐々にアルファ値を下げていくコルーチン
	private IEnumerator FadeOutCoroutine()
	{
		// SpriteRendererコンポーネントを取得
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

		// フェードアウト開始時の色を取得
		Color startColor = spriteRenderer.color;

		// 経過時間を記録するための変数
		float elapsedTime = 0f;

		// ループ処理
		while (elapsedTime < _fadeOutTime)
		{
			// 経過時間を更新
			elapsedTime += Time.deltaTime;

			// 経過時間に基づいて、新しいアルファ値を計算
			float newAlpha = 1.0f - (elapsedTime / _fadeOutTime);

			// スプライトの色を更新
			spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

			// 次のフレームまで待機
			yield return null;
		}

		// フェードアウトが完了したら、完全に透明にする
		spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

		Destroy(gameObject);
	}
}
