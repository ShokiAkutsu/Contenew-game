using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�L���ő��삷��A�j����o�^���邾���̃��\�b�h
/// </summary>
public class AnimationRegistration : MonoBehaviour
{
    Animator _anim;

	void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        AnimationDirector.Instance.RegisterAnimator(gameObject.name, _anim); // Anime��o�^����
        Debug.Log(gameObject.name);
    }
}
