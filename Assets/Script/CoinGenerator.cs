using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
	[SerializeField] GameObject[] _coinPrefab;
	[Header("�R�C�����o��������ꏊ�̐e")]
	[SerializeField] Transform _spawnPointParent;
	[Header("�R�C���o���̊Ԋu")]
	[SerializeField] float _interval = 5f;
	float _timer;
	bool _isPause = false;
	List<Transform> _spawnPoints = new List<Transform>();	// �R�C���̏o���ꏊ���i�[����List

	private void Awake()
	{
		if (_spawnPointParent == null)
		{
			Debug.LogError("�o���ꏊ�̐e�I�u�W�F�N�g���ݒ肳��Ă��܂���B");
			return;
		}

		// �e�I�u�W�F�N�g�����X�g�̍ŏ��̗v�f�Ƃ��Ēǉ�
		_spawnPoints.Add(_spawnPointParent);

		// ���̎q�I�u�W�F�N�g�����ׂă��X�g�ɒǉ�
		foreach (Transform child in _spawnPointParent)
		{
			_spawnPoints.Add(child);
		}

		Debug.Log("�o�^���ꂽ�o���ꏊ�̐��� " + _spawnPoints.Count + " �ł��B");
	}

	void Update()
	{
		if (!_isPause)
		{
			_timer += Time.deltaTime;

			if (_timer > _interval)
			{
				_timer = 0;

				int randomIndex = Random.Range(0, _spawnPoints.Count);	//�o��������ꏊ�������_���Ō���
				Transform randomSpawnPoint = _spawnPoints[randomIndex];	//���܂����ꏊ���i�[

				//�R�C���̐���
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
