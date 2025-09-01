using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTextManager : MonoBehaviour
{
	[SerializeField] Text _player1Text;
	[SerializeField] Text _player2Text;

	/// <summary>
	/// PlayerID‚É‘Î‰‚µ‚½Š‹àUI‚ÌXV‚ğ‚·‚é
	/// </summary>
	/// <param name="playerID"></param>
	/// <param name="Value"></param>
    public void UpdateUI(PlayerID playerID, int Value)
    {
		if (playerID == PlayerID.Player_1P)
		{
			if (_player1Text != null)
			{
				_player1Text.text = "Player 1: " + Value;
			}
		}
		else if (playerID == PlayerID.Player_2P)
		{
			if (_player2Text != null)
			{
				_player2Text.text = "Player 2: " + Value;
			}
		}
		else
		{
			Debug.Log("İ’è‚³‚ê‚Ä‚¢‚È‚¢ID‚ª“ü—Í‚³‚ê‚Ü‚µ‚½I");
		}
	}
}
