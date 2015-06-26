using UnityEngine;
using System.Collections;

public class GameControler : MonoBehaviour {
	private bool _levelSuccess = false;
	private bool _levelStarted = false;

	private static GameControler _instance = null;
	public static GameControler Instance {
		get {
			if (_instance == null)
				_instance = GameObject.FindObjectOfType(typeof(GameControler)) as GameControler;
			
			return _instance;
		}
	}

	void Awake() {
		_levelStarted = false;
		_instance = this;
	}

	void Start() {
		StartCoroutine(StartLevel());
	}

	public void LoadLevel(string level) {
		Application.LoadLevel(level);
	}

	public void LoadNextLevel() {
		if(Application.loadedLevel == 10)
			Application.LoadLevel(0);
		else
			Application.LoadLevel(Application.loadedLevel+1);
	}

	public void ReloadLevel() {
		Application.LoadLevel(Application.loadedLevel);
	}

	public void LevelSuccess() {
		PlayerPrefs.SetInt(Application.loadedLevelName, 1);
	}

	public void LevelFailed() {

	}

	public bool IsLevelSuccess {
		get {
			return _levelSuccess;
		}

		set {
			_levelSuccess = true;
		}
	}

	public bool IsLevelStarted {
		get {
			return _levelStarted;
		}
	}

	IEnumerator StartLevel() {
		yield return new WaitForSeconds(1);

		_levelStarted = true;
	}
}
