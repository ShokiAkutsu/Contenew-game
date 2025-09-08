using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
	[SerializeField] GameObject[] _coinPrefab;
	[Header("コインを出現させる場所の親")]
	[SerializeField] Transform _spawnPointParent;
	[Header("コイン出現の間隔")]
	[SerializeField] float _interval = 5f;
	float _timer;
	bool _isPause = false;
	List<Transform> _spawnPoints = new List<Transform>();	// コインの出現場所を格納するList

	private void Awake()
	{
		if (_spawnPointParent == null)
		{
			Debug.LogError("出現場所の親オブジェクトが設定されていません。");
			return;
		}

		// 親オブジェクトをリストの最初の要素として追加
		_spawnPoints.Add(_spawnPointParent);

		// その子オブジェクトもすべてリストに追加
		foreach (Transform child in _spawnPointParent)
		{
			_spawnPoints.Add(child);
		}

		Debug.Log("登録された出現場所の数は " + _spawnPoints.Count + " です。");
	}

	void Update()
	{
		if (!_isPause)
		{
			_timer += Time.deltaTime;

			if (_timer > _interval)
			{
				_timer = 0;

				int randomIndex = Random.Range(0, _spawnPoints.Count);	//出現させる場所をランダムで決定
				Transform randomSpawnPoint = _spawnPoints[randomIndex];	//決まった場所を格納

				//コインの生成
				GameObject coin = Instantiate(_coinPrefab[0], randomSpawnPoint.position, Quaternion.identity);
			}
		}
	}

	private void OnEnable()
	{
		PauseManager.OnPause += Pause;
		PauseManager.OnResume += Resume;
	}

	private void OnDisable()
	{
		PauseManager.OnPause -= Pause;
		PauseManager.OnResume -= Resume;
	}

	private void Pause()
	{
		_isPause = true;
	}

	void Resume()
	{
		_isPause = false;
	}
}
