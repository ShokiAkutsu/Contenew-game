using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveUIManager : MonoBehaviour
{
    [SerializeField] Image _1PTextImage;
    [SerializeField] Image _2PTextImage;

	public void UpdateUI(PlayerID playerID)
	{
		bool _isActive = playerID == PlayerID.Player_1P;

		_1PTextImage.gameObject.SetActive(_isActive);
		_2PTextImage.gameObject.SetActive(!_isActive);
	}
}
