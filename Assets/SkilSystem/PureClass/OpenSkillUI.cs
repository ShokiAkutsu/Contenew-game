using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class OpenSkillUI
{
	[SerializeField] Image _icon;
	[SerializeField] Text _cost;
	public Image Icon => _icon;
	public Text Cost => _cost;

	public OpenSkillUI(Image icon, Text text)
	{
		_icon = icon;
		_cost = text;
	}

	public void UpdateUI(Sprite icon, int cost)
	{
		_icon.sprite = icon;
		_cost.text = cost.ToString();
	}
}
