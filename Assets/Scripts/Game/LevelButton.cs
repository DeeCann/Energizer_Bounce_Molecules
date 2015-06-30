using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

	public GameManager.GlobalLevelsNames LevelName;
	
	private GameObject _activeIco;
	private GameObject _unactiveIco;
	private Image _glowEffect;

	private bool _isLocked = true;

	void Start () {
		Debug.Log("test");
		if(PlayerPrefs.HasKey(LevelName.ToString())) {
			_isLocked = false;

			_activeIco = transform.FindChild("ActiveLevel").gameObject;
			_unactiveIco = transform.FindChild("UnactiveLevel").gameObject;
			_glowEffect = transform.FindChild("Glow").GetComponent<Image>();

			_activeIco.SetActive(true);
			_unactiveIco.SetActive(false);
			_glowEffect.enabled = true;
		}
	}

	public void PlayLevel() {
		if(!_isLocked) {
			GameControler.Instance.LoadLevel(LevelName.ToString());
		}
	}
}
