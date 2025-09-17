using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSkillManager : MonoBehaviour
{
    SkillDeckManager _deck;
    // 手札表示
    [SerializeField] Image _skillImageL;
    [SerializeField] Image _skillImageC;
    [SerializeField] Image _skillImageR;

    [SerializeField] Text _costTextL;
    [SerializeField] Text _costTextC;
    [SerializeField] Text _costTextR;

	// SkillPositionと対応するImageを管理する辞書
	Dictionary<SkillPosition, SkillUI> _openSkillsUI = new Dictionary<SkillPosition, SkillUI>();

    struct SkillUI
    { 
        public Image _icon;
        public Text _cost;
        public Image Icon => _icon;
        public Text Cost => _cost;

        public SkillUI(Image icon, Text text)
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

	void Start()
    {
		_deck = GameObject.FindFirstObjectByType<SkillDeckManager>();

        _openSkillsUI[SkillPosition.Left] = new SkillUI(_skillImageL, _costTextL);
		_openSkillsUI[SkillPosition.Center] = new SkillUI(_skillImageC, _costTextC);
		_openSkillsUI[SkillPosition.Right] = new SkillUI(_skillImageR, _costTextR);
	}

    public void SkillUpdate(SkillSO skill, SkillPosition skillPos)
    {
		if (_openSkillsUI.TryGetValue(skillPos, out SkillUI skillUI))
		{
			// UI要素を直接更新
			if (skillUI._cost != null)
				skillUI._cost.text = skill.Cost.ToString();

			if (skillUI._icon != null)
				skillUI._icon.sprite = skill.Icon;

			_openSkillsUI[skillPos] = skillUI; // 辞書を更新して、UIを反映
		}
	}
}
