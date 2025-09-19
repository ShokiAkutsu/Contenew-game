using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    [SerializeField] GameObject _effect2;
    [SerializeField] float _waitTime = 0.5f;
    
    void Start()
    {
        StartCoroutine(Chenge());
    }

    IEnumerator Chenge()
    {
        yield return new WaitForSeconds(0.5f);
		Instantiate(_effect2, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
	}
}
