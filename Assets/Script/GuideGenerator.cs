using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _guidePrefab;
	[Header("‘«ê‚Ì‘¬‚³")]
	[SerializeField] float _moveSpeed = 3f;
    [Header("‘«ê‚ğoŒ»‚³‚¹‚é‚‚³")]
    [SerializeField, Range(5f, 10f)] float _instPosY = 10f;
	[Header("‘«ê‚ÌŠÔŠu")]
	[SerializeField] float _interval = 3f;
	float _timer;
    int _rastIndex;     //‚P‚Â‘O‚ÉoŒ»‚³‚¹‚½‘«ê‚Ì”š‚ğŠi”[
    bool _isPause = false;

	private void Start()
	{
        // Ši”[”Ô†”ÍˆÍŠO‚Ì”’l‚ğŠi”[
        _rastIndex = _guidePrefab.Length + 1;
	}

	void Update()
    {
        if (!_isPause)
        {
			_timer += Time.deltaTime;

			if (_timer > _interval)
			{
				_timer = 0;

				// oŒ»‚³‚¹‚é‘«ê‚ğƒ‰ƒ“ƒ_ƒ€‚ÅŒˆ‚ß‚é
				int index = Random.Range(0, _guidePrefab.Length);

				// “¯‚¶‘«ê‚¾‚ÆÏ‚Ş‰Â”\«‚ª‚ ‚é‚½‚ßA•ÏX‚·‚é
				if (index == _rastIndex)
				{
					index = (index + 1) % _guidePrefab.Length;
				}
				// ¶¬‚·‚é‘«ê”Ô†‚ğŠi”[
				_rastIndex = index;

				//‘«ê‚Ì¶¬
				GameObject guide = Instantiate(_guidePrefab[index], new Vector3(0, _instPosY, 0), Quaternion.identity);
				Rigidbody2D rb = guide.GetComponent<Rigidbody2D>();  //‘«ê‚ÌRigitBody‚ğæ“¾
				rb.velocity = Vector2.down * _moveSpeed;            //ì¬‚µ‚½‘«ê‚É—Í‚ğ—^‚¦‚é
			}
		}
    }

	// ‚±‚±‚É‘«ê‚ÌƒXƒs[ƒh•Ï‰»‚ğ‹Lq‚µ‚Ä‚¢‚¢‚©–À‚Á‚Ä‚¢‚é

	private void OnEnable()
	{
		PauseManager.OnPause += Pause;
		PauseManager.OnResume += Resume;
	}

	private void OnDisable()
	{
		PauseManager.OnPause -= Pause;
		PauseManager.OnResume -= Resume;
	}

	private void Pause()
	{
		_isPause = true;
	}

    void Resume()
    {
        _isPause = false;
    }
}
