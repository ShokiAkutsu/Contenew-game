using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillBeam : MonoBehaviour, ISkillEffect
{
	[SerializeField] GameObject _redShot; // 赤玉
	[SerializeField] GameObject _blueShot; // 青玉
	[SerializeField] GameObject _warning; // 警告マーク
	[SerializeField] float _warningSec = 1f; // 警告マークを出す時間
	[SerializeField] float _speed = 3f;
	bool _isPlayer1; // 使用Playerが1Pかどうか

	SkillBeam _skillBeam;

	public void Execute(PlayerID usePlayerID)
	{
		_isPlayer1 = usePlayerID == PlayerID.Player_1P;
		// 相手のIDを格納する
		PlayerID targetID = _isPlayer1 ? PlayerID.Player_2P : PlayerID.Player_1P;
		ShotSkillStart(targetID);
	}

	void ShotSkillStart(PlayerID targetID)
	{
		// 打ち出す場所を定義
		float _shotX = 15f;

		GameObject inShot = _isPlayer1 ? _redShot : _blueShot; // スキルを使ったプレイヤーで変える
		Vector3 targetPos = PlayerIDManager.Instance.GetPlayerPosition(targetID); // 相手の場所を取る

		bool _isPlusX = targetPos.x > 0;

		// 打ち出す
		// 向きを調整
		Vector3 shotPosition = new Vector3(_shotX * (_isPlayer1 ? -1 : 1), targetPos.y);
		GameObject shot = Instantiate(inShot, shotPosition, Quaternion.identity);

		// 進行方向に向かってビームを回転させる
		float angle = _isPlusX ? -90 : 90;
		shot.transform.rotation = Quaternion.Euler(0, 0, angle);

		// 動かす
		Vector3 vec = _isPlusX ? Vector3.right : Vector3.left;
		shot.GetComponent<Rigidbody2D>().velocity = vec * _speed;
	}
}
