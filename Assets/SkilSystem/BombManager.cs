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

	// �Q�[�����ŉ����C�x���g���N�������\�b�h
	void SpawnPowerUp()
	{
		Instantiate(_effect, gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
