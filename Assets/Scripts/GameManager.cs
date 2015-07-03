using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public enum GlobalLevelsNames
	{
		Basic_1,
		Basic_2,
		Basic_3,
		Basic_4,
		Basic_5,
		Basic_6,
		Basic_7,
		Basic_8,
		Basic_9,
		Basic_10
	}

	public Dictionary<string, string> moleculesUnlocLevels = new Dictionary<string, string>();

	private static GameManager _instance = null;
	public static GameManager Instance {
		get {
			if (_instance == null)
				_instance = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
			
			return _instance;
		}
	}

	void Awake() {

		_instance = this;

		if(!PlayerPrefs.HasKey("Basic_1"))
			PlayerPrefs.SetInt("Basic_1", 1);

		if(!PlayerPrefs.HasKey("plastic"))
			PlayerPrefs.SetInt("plastic", 1);

		Application.targetFrameRate = 60;

		moleculesUnlocLevels.Clear();
		moleculesUnlocLevels.Add("Basic_2", "gel");
		moleculesUnlocLevels.Add("Basic_4", "iron");
		moleculesUnlocLevels.Add("Basic_6", "rubber");
		moleculesUnlocLevels.Add("Basic_8", "wood");
	}
}
