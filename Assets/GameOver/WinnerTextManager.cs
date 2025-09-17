using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerTextManager : MonoBehaviour
{
	[SerializeField] Text _text;

	void Start()
	{
		string winner = PlayerPrefs.GetString("Winner");
		_text.text = winner;
	}
}
