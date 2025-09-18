using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillBeam : MonoBehaviour, ISkillEffect
{
	[SerializeField] GameObject _redShot; // �ԋ�
	[SerializeField] GameObject _blueShot; // ��
	[SerializeField] GameObject _warning; // �x���}�[�N
	[SerializeField] float _warningSec = 1f; // �x���}�[�N���o������
	[SerializeField] float _speed = 3f;
	bool _isPlayer1; // �g�pPlayer��1P���ǂ���

	SkillBeam _skillBeam;

	public void Execute(PlayerID usePlayerID)
	{
		_isPlayer1 = usePlayerID == PlayerID.Player_1P;
		// �����ID���i�[����
		PlayerID targetID = _isPlayer1 ? PlayerID.Player_2P : PlayerID.Player_1P;
		ShotSkillStart(targetID);
	}

	void ShotSkillStart(PlayerID targetID)
	{
		// �ł��o���ꏊ���`
		float _shotX = 15f;

		GameObject inShot = _isPlayer1 ? _redShot : _blueShot; // �X�L�����g�����v���C���[�ŕς���
		Vector3 targetPos = PlayerIDManager.Instance.GetPlayerPosition(targetID); // ����̏ꏊ�����

		bool _isPlusX = targetPos.x > 0;

		// �ł��o��
		// �����𒲐�
		Vector3 shotPosition = new Vector3(_shotX * (_isPlayer1 ? -1 : 1), targetPos.y);
		GameObject shot = Instantiate(inShot, shotPosition, Quaternion.identity);

		// �i�s�����Ɍ������ăr�[������]������
		float angle = _isPlusX ? -90 : 90;
		shot.transform.rotation = Quaternion.Euler(0, 0, angle);

		// ������
		Vector3 vec = _isPlusX ? Vector3.right : Vector3.left;
		shot.GetComponent<Rigidbody2D>().velocity = vec * _speed;
	}
}
