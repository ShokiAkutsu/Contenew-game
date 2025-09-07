using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _guidePrefab;
	[Header("����̑���")]
	[SerializeField] float _moveSpeed = 3f;
    [Header("������o�������鍂��")]
    [SerializeField, Range(5f, 10f)] float _instPosY = 10f;
	[Header("����̊Ԋu")]
	[SerializeField] float _interval = 3f;
	float _timer;
    int _rastIndex;     //�P�O�ɏo������������̐������i�[
    bool _isPause = false;

	private void Start()
	{
        // �i�[�ԍ��͈͊O�̐��l���i�[
        _rastIndex = _guidePrefab.Length + 1;
	}

	void Update()
    {
        if (!_isPause)
        {
			_timer += Time.deltaTime;

			if (_timer > _interval)
			{
				_timer = 0;

				// �o�������鑫��������_���Ō��߂�
				int index = Random.Range(0, _guidePrefab.Length);

				// �������ꂾ�Ɛςމ\�������邽�߁A�ύX����
				if (index == _rastIndex)
				{
					index = (index + 1) % _guidePrefab.Length;
				}
				// �������鑫��ԍ����i�[
				_rastIndex = index;

				//����̐���
				GameObject guide = Instantiate(_guidePrefab[index], new Vector3(0, _instPosY, 0), Quaternion.identity);
				Rigidbody2D rb = guide.GetComponent<Rigidbody2D>();  //�����RigitBody���擾
				rb.velocity = Vector2.down * _moveSpeed;            //�쐬��������ɗ͂�^����
			}
		}
    }

	// �����ɑ���̃X�s�[�h�ω����L�q���Ă����������Ă���

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
