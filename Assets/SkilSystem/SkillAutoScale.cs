using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAutoScale : MonoBehaviour
{
	// オブジェクトが到達する最大スケール
	[SerializeField] float _maxScale = 3f;
	// スケール変更の速さ
	[SerializeField] float _scaleSpeed = 1f;

	private void Update()
	{
		// オブジェクトのスケールを毎フレーム少しずつ大きくする
		transform.localScale += Vector3.one * _scaleSpeed * Time.deltaTime;

		// もし、いずれかの軸のスケールが設定した最大スケールを超えたら
		if (transform.localScale.x >= _maxScale)
		{
			// このゲームオブジェクトを破棄する
			Destroy(gameObject);
		}
	}
}
