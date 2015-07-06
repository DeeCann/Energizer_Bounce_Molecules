using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

	public AudioClip _failTouch;
	public AudioClip _properTouch;

	public GameManager.GlobalLevelsNames LevelName;
	
	private GameObject _activeIco;
	private GameObject _unactiveIco;
	private Image _glowEffect;

	private bool _isLocked = true;

	void Start () {
		if(PlayerPrefs.HasKey(LevelName.ToString())) {
			_isLocked = false;

			_activeIco = transform.FindChild("ActiveLevel").gameObject;
			_unactiveIco = transform.FindChild("UnactiveLevel").gameObject;

			if(transform.FindChild("Glow"))
				_glowEffect = transform.FindChild("Glow").GetComponent<Image>();

			_activeIco.SetActive(true);
			_unactiveIco.SetActive(false);

			if(_glowEffect != null)
				_glowEffect.enabled = true;
		}
	}

	public void PlayLevel() {
		Debug.Log("platy");
		if(!_isLocked) {
			GameControler.Instance.LoadLevel(LevelName.ToString());
			GetComponent<AudioSource>().clip = _properTouch;
			GetComponent<AudioSource>().Play();
		} else {
			GetComponent<AudioSource>().clip = _failTouch;
			GetComponent<AudioSource>().Play();
		}
	}
}
