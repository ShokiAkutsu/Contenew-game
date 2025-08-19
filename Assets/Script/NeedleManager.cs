using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleManager : MonoBehaviour
{
    PauseManager _pause;
    ContinueManager _continue;

    // Start is called before the first frame update
    void Start()
    {
        _pause = GameObject.FindObjectOfType<PauseManager>();
        _continue = GameObject.FindObjectOfType<ContinueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
        {
            Debug.Log("‚Æ‚°‚ª“–‚½‚è‚Ü‚µ‚½");
            _pause.Switching();
            _continue.PlayerDead(collision.gameObject);
        }
	}
}
