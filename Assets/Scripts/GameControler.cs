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
		FadeScreen.Instance.StartScene();

		StartCoroutine(StartLevel());
	
		if(Application.loadedLevel == 0)
			PlayerPrefs.DeleteKey("LastMoleculeSelected");

		if(Application.loadedLevel > 0 && PlayerPrefs.HasKey("LastMoleculeSelected"))
			ChangeMolecule(PlayerPrefs.GetString("LastMoleculeSelected"));

		SFXControler.Instance.VolumeUp();
	}

	public void LoadLevel(string level) {
		FadeScreen.Instance.EndScene(level);
	}

	public void LoadNextLevel() {
		PlayerPrefs.DeleteKey("LastMoleculeSelected");

		if(Application.loadedLevel == 10)
			FadeScreen.Instance.EndScene(null, 1);
		else
			FadeScreen.Instance.EndScene(null, Application.loadedLevel+1);
	}

	public void ReloadLevel(int reloadAfterTime = 0) {
		StartCoroutine(ReloadAfterTime(reloadAfterTime));
	}

	public void LevelSuccess() {
		PlayerPrefs.SetInt("Basic_"+(System.Convert.ToInt16( Application.loadedLevelName.Substring(6))+1), 1);
		CheckForUnlockMolecule();

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
		if(GameManager.Instance.moleculesUnlocLevels.ContainsKey(Application.loadedLevelName)) {

			PlayerPrefs.SetInt(GameManager.Instance.moleculesUnlocLevels[Application.loadedLevelName], 1);
			NewMolecule.Instance.ShowNewMolecule(GameManager.Instance.moleculesUnlocLevels[Application.loadedLevelName]);
			StartCoroutine(LoadNextLevelWithTimer(3));
		} else
			LoadNextLevel();
	}

	public bool ChangeMolecule(string _newMolecule) {
		if(PlayerPrefs.HasKey(_newMolecule)) {
			if(MyMolecule == null)
				MyMolecule = GameObject.FindGameObjectWithTag("Molecule").transform;

			GameObject newMolecule = (GameObject)Instantiate(Resources.Load("Molecules/"+_newMolecule), MyMolecule.transform.position, Quaternion.identity);
			newMolecule.transform.localScale = Vector3.one * 0.3f;
			Destroy(MyMolecule.gameObject);
			MyMolecule = newMolecule.transform;

			return true;
		} else
			return false;
	}

	IEnumerator StartLevel() {
		yield return new WaitForSeconds(1);

		_levelStarted = true;
	}

	IEnumerator ReloadAfterTime(int time) {
		yield return new WaitForSeconds(time);

		FadeScreen.Instance.EndScene(null, Application.loadedLevel);
	}

	IEnumerator LoadNextLevelWithTimer(int _timer) {
		yield return new WaitForSeconds(_timer);
		SFXControler.Instance.VolumeUp();
		LoadNextLevel();
	}
}
