using UnityEngine;
using System.Collections;

public class EndHole : MonoBehaviour {
	private Transform _molecule;
	private float _endRotation = 5;

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == Tags.Molecule) {
			_molecule = other.transform;

			_molecule.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			StartCoroutine(LerpMoleculeToHole());
			StartCoroutine(RotateMolecule());
			GetComponent<AudioSource>().Play();
		}
	}

	IEnumerator RotateMolecule() {
		while(_endRotation < 10000000) {
			_molecule.rotation = Quaternion.AngleAxis(_endRotation, new Vector3(0,0,1));//(_molecule.transform.position, Vector2.up, 20);
			_endRotation = _endRotation * 1.2f;
			yield return 0;
		}
	}

	IEnumerator LerpMoleculeToHole() {
		while(Vector3.Distance(transform.position, _molecule.position) > 0.05f) {

			GameControler.Instance.IsLevelSuccess = true;
			_molecule.position = Vector3.Lerp(_molecule.position, transform.position, Time.deltaTime * 4);

			yield return 0;
		}
		_molecule.position = transform.position;
		StartCoroutine(ScaleDownMolecule());
	}

	IEnumerator ScaleDownMolecule() {
		while(_molecule.localScale.magnitude > 0.01f) {
			_molecule.localScale = Vector3.Lerp(_molecule.localScale, Vector2.zero, Time.deltaTime * 2);

			yield return 0;
		}

		GameControler.Instance.LevelSuccess();
	}
}
