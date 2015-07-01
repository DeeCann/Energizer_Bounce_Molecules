using UnityEngine;
using System.Collections;

public class SFXControler : MonoBehaviour {

	private static SFXControler _instance = null;

	public static SFXControler Instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType(typeof(SFXControler)) as SFXControler;
			}
			return _instance;
		}
	}
	
	void Awake() {
		if(_instance == null)
			GetComponent<AudioSource>().Play();

		_instance = this;	
		DontDestroyOnLoad(this.gameObject);
	}

}
