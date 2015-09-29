using UnityEngine;
using System.Collections;

public class RollingBand : MonoBehaviour {

	private Animator _lateFirstArrow;

	void Start () {
		if(gameObject.name == "BandExtra") {
			if(PlayerPrefs.GetInt("UnlockMaxBounce") == 2)
				gameObject.SetActive(true);
			else {
				gameObject.SetActive(false);
				return;
			}
		}

		_lateFirstArrow = transform.GetChild(0).GetComponent<Animator>();

		transform.GetChild(1).GetComponent<Animator>().SetBool("Play", true);
		StartCoroutine(LateFirstArrow());
	}

	IEnumerator LateFirstArrow() {
		yield return new WaitForSeconds(0.50f);
		_lateFirstArrow.SetBool("Play", true);
	}
}
