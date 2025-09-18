using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSkillManager : MonoBehaviour
{
    SkillDeckManager _deck;
    OpenSkillUI _skillUI;
    // èD•\¦
    [SerializeField] Image _skillImageL;
    [SerializeField] Image _skillImageC;
    [SerializeField] Image _skillImageR;
    [SerializeField] Text _costTextL;
    [SerializeField] Text _costTextC;
    [SerializeField] Text _costTextR;
	// SkillPosition‚Æ‘Î‰‚·‚éImage‚ğŠÇ—‚·‚é«‘
	Dictionary<SkillPosition, OpenSkillUI> _openSkillsUI = new Dictionary<SkillPosition, OpenSkillUI>();

	private void Awake()
	{
		_deck = GameObject.FindFirstObjectByType<SkillDeckManager>();

		_openSkillsUI[SkillPosition.Left] = new OpenSkillUI(_skillImageL, _costTextL);
		_openSkillsUI[SkillPosition.Center] = new OpenSkillUI(_skillImageC, _costTextC);
		_openSkillsUI[SkillPosition.Right] = new OpenSkillUI(_skillImageR, _costTextR);
	}

    public void SkillUpdate(SkillSO skill, SkillPosition skillPos)
    {
		Debug.Log($"{skill}‚ª‚«‚½‚æ");

		if (_openSkillsUI.TryGetValue(skillPos, out OpenSkillUI skillUI))
		{
			skillUI.UpdateUI(skill.Icon, skill.Cost); // UI”½‰f
		}
	}
}
