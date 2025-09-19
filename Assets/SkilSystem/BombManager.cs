using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
	[SerializeField] GameObject _effect;

	void Start()
	{
		Invoke("SpawnPowerUp", 5f);
	}

	// ゲーム内で何かイベントを起こすメソッド
	void SpawnPowerUp()
	{
		Instantiate(_effect, gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
