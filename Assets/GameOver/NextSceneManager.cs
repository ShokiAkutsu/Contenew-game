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
        // 1Pのキー入力チェック（AまたはDキー）
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            _isReady1P = true;
            Debug.Log("1P Ready!");
        }

        // 2Pのキー入力チェック（JまたはLキー）
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L))
        {
            _isReady2P = true;
            Debug.Log("2P Ready!");
        }

        // 両プレイヤーが準備完了したかチェック
        if (_isReady1P && _isReady2P)
        {
            // 両方がAとJを押した場合のみゲーム開始
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.J))
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                // それ以外の組み合わせならタイトルに戻る
                SceneManager.LoadScene(0);
            }
        }
    }
}
