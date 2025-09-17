using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelColorManager : MonoBehaviour
{
    [SerializeField] Image _panel;

    void Start()
    {
		float r = PlayerPrefs.GetFloat("ColorR");
		float g = PlayerPrefs.GetFloat("ColorG");
		float b = PlayerPrefs.GetFloat("ColorB");
		_panel.color = new Color(r, g, b);
	}
}
