using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneManager : MonoBehaviour
{
    bool _isReady1P = false;
    bool _isReady2P = false;

    void Update()
    {
        // 1P�̃L�[���̓`�F�b�N�iA�܂���D�L�[�j
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            _isReady1P = true;
            Debug.Log("1P Ready!");
        }

        // 2P�̃L�[���̓`�F�b�N�iJ�܂���L�L�[�j
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L))
        {
            _isReady2P = true;
            Debug.Log("2P Ready!");
        }

        // ���v���C���[�����������������`�F�b�N
        if (_isReady1P && _isReady2P)
        {
            // ������A��J���������ꍇ�̂݃Q�[���J�n
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.J))
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                // ����ȊO�̑g�ݍ��킹�Ȃ�^�C�g���ɖ߂�
                SceneManager.LoadScene(0);
            }
        }
    }
}
