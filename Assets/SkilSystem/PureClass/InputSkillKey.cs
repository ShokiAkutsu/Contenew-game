using System.Collections;
using UnityEngine;

[System.Serializable]
public class InputSkillKey
{
	KeyCode _leftSkill;
	KeyCode _centerSkill;
	KeyCode _rightSkill;

	public KeyCode LeftSkill => _leftSkill;
	public KeyCode CenterSkill => _centerSkill;
	public KeyCode RightSkill => _rightSkill;

	public InputSkillKey(KeyCode left, KeyCode center, KeyCode right)
	{
		_leftSkill = left;
		_centerSkill = center;
		_rightSkill = right;
	}
}
