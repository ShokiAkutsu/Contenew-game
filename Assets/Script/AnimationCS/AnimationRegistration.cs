using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRegistration : MonoBehaviour
{
    Animator _anim;

	void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        AnimationDirector.Instance.RegisterAnimator(gameObject.name, _anim); // Anime‚ð“o˜^‚·‚é
        Debug.Log(gameObject.name);
    }
}
