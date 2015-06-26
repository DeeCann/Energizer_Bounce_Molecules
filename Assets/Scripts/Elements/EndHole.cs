using UnityEngine;
using System.Collections;

public class EndHole : MonoBehaviour {
	private Transform _molecule;
	private bool _trackDistance = false;

//	void FixedUpdate() {
//		if(_trackDistance) {
//			if(Vector3.Distance(transform.position, _molecule.position) <= GetComponent<CircleCollider2D>().radius / 4) {
//				_molecule.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
//				StartCoroutine(LerpMoleculeToHole());
//			}
//		}
//	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == Tags.Molecule) {
			_molecule = other.transform;
			_trackDistance = true;

			_molecule.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			StartCoroutine(LerpMoleculeToHole());
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.tag == Tags.Molecule)
			_trackDistance = false;
	}

	IEnumerator LerpMoleculeToHole() {
		while(Vector3.Distance(transform.position, _molecule.position) > 0.05f) {
			GameControler.Instance.IsLevelSuccess = true;
			_molecule.position = Vector3.Lerp(_molecule.position, transform.position, Time.deltaTime * 4);

			yield return 0;
		}

		StartCoroutine(ScaleDownMolecule());
	}

	IEnumerator ScaleDownMolecule() {
		while(_molecule.localScale.magnitude > 0.01f) {
			_molecule.localScale = Vector3.Lerp(_molecule.localScale, Vector2.zero, Time.deltaTime * 2);
			
			yield return 0;
		}

		GameControler.Instance.LoadNextLevel();
	}
}
