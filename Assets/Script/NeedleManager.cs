using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleManager : MonoBehaviour
{
    PlayerDeadManager _dead;

    // Start is called before the first frame update
    void Start()
    {
        _dead = GameObject.FindObjectOfType<PlayerDeadManager>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
        {
            Debug.Log("‚Æ‚°‚ª“–‚½‚è‚Ü‚µ‚½");
            GameObject player = collision.gameObject;
            StartCoroutine(_dead.IsContinue(player));
        }
	}
}
