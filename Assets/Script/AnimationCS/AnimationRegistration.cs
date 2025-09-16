using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スキルで操作するアニメを登録するだけのメソッド
/// </summary>
public class AnimationRegistration : MonoBehaviour
{
    Animator _anim;

	void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        AnimationDirector.Instance.RegisterAnimator(gameObject.name, _anim); // Animeを登録する
        Debug.Log(gameObject.name);
    }
}
