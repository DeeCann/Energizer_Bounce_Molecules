using UnityEngine;
using System.Collections;

public class GameControler : MonoBehaviour {

	private static GameControler _instance = null;
	public static GameControler Instance {
		get {
			if (_instance == null)
				_instance = GameObject.FindObjectOfType(typeof(GameControler)) as GameControler;
			
			return _instance;
		}
	}

	void Awake() {
		_instance = this;
	}

	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel+1);
	}

	public void ReloadLevel() {
		
	}

	public void LevelSuccess() {

	}

	public void LevelFailed() {

	}
}
