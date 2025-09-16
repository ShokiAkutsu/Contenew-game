using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameSceneManager : MonoBehaviour
{
	GlowEffect[] _glow;
	bool _isNext;
	int _inGameIndex = 1;

	private void Start()
	{
		_glow = GameObject.FindObjectsOfType<GlowEffect>();
	}

	void Update()
    {
		_isNext = true;

        foreach (GlowEffect g in _glow)
		{
			if(!g.Active)
			{
				_isNext = false;
				break;
			}
		}

		if (_isNext)
		{
			SceneManager.LoadScene(_inGameIndex);
		}
    }
}
