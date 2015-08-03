using UnityEngine;
using System.Collections;

public class Glass : MonoBehaviour {
	[SerializeField]
	private ParticleSystem particles;

	void OnCollisionEnter2D(Collision2D other) {
		if(other.collider.tag == Tags.Molecule) {
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<Shadow>().enabled = false;
			GetComponent<BoxCollider2D>().enabled = false;
			Destroy(transform.FindChild("New Game Object").gameObject);
			particles.Emit(100);
			Destroy(this, 1);
		}
	}

}
