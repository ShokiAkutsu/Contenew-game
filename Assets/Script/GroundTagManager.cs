using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GroundTagManager : MonoBehaviour
{
	// 足場の状態を格納
	Dictionary<Rigidbody2D, PhysicsState> _groundStates = new Dictionary<Rigidbody2D, PhysicsState>();

	private struct PhysicsState
	{
		public Vector3 _velocity;
		public float _angularVelocity;
	}

	private void OnEnable()
	{
		PauseManager.OnPause += Stopping;
		PauseManager.OnResume += Starting;
	}

	private void OnDisable()
	{
		PauseManager.OnPause -= Stopping;
		PauseManager.OnResume -= Starting;
	}

	public void Stopping()
	{
		// Linqを使用する課題 勉強のためにコメント
		GameObject.FindGameObjectsWithTag("Ground")		// GroundタグのGameObjectを全取得
		.Select(obj => obj.GetComponent<Rigidbody2D>()) // RigidBody2Dを取得して{選んで}返す
		.Where(rb => rb != null)						// rbのnullチェック {Whereはboolできるやつ}
		.ToList()										// リスト化 {trueならリスト化}
		.ForEach(rb =>									// 動きを止めるためのforeachを行う {リストをまわす}
		{
			_groundStates[rb] = new PhysicsState
			{
				_velocity = rb.velocity, 
				_angularVelocity = rb.angularVelocity
			};
			rb.Sleep();// 動きを停止
		});
	}

	public void Starting()
	{
		// 作成しているステータスを基にする
		_groundStates
		.Where(kvp => kvp.Key != null)					// nullチェック
		.ToList()										// リスト化する
		.ForEach(kvp =>									// リストをまわす
		{
			Rigidbody2D rb = kvp.Key;
			rb.WakeUp(); // 動きを再開

			PhysicsState state = kvp.Value; // 足場の状態を渡す
			// 足場の状態を元に戻す
			rb.velocity = state._velocity;  
			rb.angularVelocity = state._angularVelocity;
		});

		_groundStates.Clear(); // Dictionaryを初期化
	}
}
