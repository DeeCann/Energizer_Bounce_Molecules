using UnityEngine;
using System.Collections;

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

	void Awake() {
		if(!PlayerPrefs.HasKey("Basic_1"))
			PlayerPrefs.SetInt("Basic_1", 1);
	}
}
