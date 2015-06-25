using UnityEngine;
using System.Collections;

public class TopMenuControler : MonoBehaviour {

	public void Reload() {
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Exit() {
		Application.LoadLevel(0);
	}
}
