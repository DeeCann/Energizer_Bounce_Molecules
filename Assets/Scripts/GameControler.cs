using UnityEngine;
using System.Collections;

public class GameControler : MonoBehaviour {
	private bool _levelSuccess = false;
	private bool _levelStarted = false;
	
	private int _collisionsCounter = 0;

	private Transform _myMolecule;

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

		_collisionsCounter = 0;
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
		CheckForUnlockMolecule();
		LoadNextLevel();
	}

	public void LevelFailed() {
		ReloadLevel();
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

	public int CollisionCounter {
		set {
			_collisionsCounter = value;
		}

		get {
			return _collisionsCounter;
		}
	}

	public Transform MyMolecule {
		set {
			_myMolecule = value;
		}

		get {
			return _myMolecule;
		}
	}

	private void CheckForUnlockMolecule() {
		if(GameManager.Instance.moleculesUnlocLevels.ContainsKey(Application.loadedLevelName))
			PlayerPrefs.SetInt(GameManager.Instance.moleculesUnlocLevels[Application.loadedLevelName], 1);
	}

	public void ChangeMolecule(string _newMolecule) {
		if(PlayerPrefs.HasKey(_newMolecule)) {
			GameObject newMolecule = (GameObject)Instantiate(Resources.Load("Molecules/"+_newMolecule), MyMolecule.transform.position, Quaternion.identity);
			newMolecule.transform.localScale = Vector3.one * 0.3f;
			Destroy(MyMolecule.gameObject);
			MyMolecule = newMolecule.transform;
		}
	}

	IEnumerator StartLevel() {
		yield return new WaitForSeconds(1);

		_levelStarted = true;
	}
}
