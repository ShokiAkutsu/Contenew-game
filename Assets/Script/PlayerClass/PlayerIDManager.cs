using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIDManager : MonoBehaviour
{
	public static PlayerIDManager Instance { get; private set; }

	Dictionary<PlayerID, GameObject> _playerDictionary =
		new Dictionary<PlayerID, GameObject>();

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		PlayerController[] allPlayers = FindObjectsOfType<PlayerController>();
		foreach (PlayerController player in allPlayers)
		{
			_playerDictionary[player.PlayerID] = player.gameObject;
		}
	}

	/// <summary>
	/// PlayerのGameObjectを返り値で渡すメソッド
	/// </summary>
	/// <param name="playerID"></param>
	/// <returns></returns>
	public GameObject GetPlayerGameObject(PlayerID playerID)
	{
		if (_playerDictionary.TryGetValue(playerID, out GameObject playerObj))
		{
			return playerObj;
		}
		return null;
	}

	/// <summary>
	/// PlayerのGameObjectについているスクリプトを返す
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="playerID"></param>
	/// <returns></returns>
	public T GetPlayerComponent<T>(PlayerID playerID) where T : Component
	{
		GameObject playerObj = GetPlayerGameObject(playerID);
		return playerObj != null ? playerObj.GetComponent<T>() : null;
	}
}
