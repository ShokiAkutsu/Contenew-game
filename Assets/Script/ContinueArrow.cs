using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueArrow : MonoBehaviour
{
    // ’S“–‚·‚éImage‚ðŠi”[
    [SerializeField] Image _leftArrow;
    [SerializeField] Image _rightArrow;
    // •Ï‰»‚³‚¹‚é‰æ‘œ‚ðŠi”[
    // 1P
    [SerializeField] Sprite _leftArrow1P;
    [SerializeField] Sprite _rightArrow1P;
    // 2P
    [SerializeField] Sprite _leftArrow2P;
    [SerializeField] Sprite _rightArrow2P;

    public void UpdateUI(PlayerID playerID)
    {
		_leftArrow.sprite = playerID == PlayerID.Player_1P ? _leftArrow1P : _leftArrow2P;
		_rightArrow.sprite = playerID == PlayerID.Player_1P ? _rightArrow1P : _rightArrow2P;
	}
}
