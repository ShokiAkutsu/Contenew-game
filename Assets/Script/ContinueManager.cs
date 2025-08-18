using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueManager : MonoBehaviour
{
    [SerializeField] ContinueCost _cost;
    [SerializeField] Canvas _canvas;

	bool _isShow = false;

	public void ToggleContinueUI()
	{
		_isShow = !_isShow;

		_canvas.gameObject.SetActive(_isShow);
	}
}
