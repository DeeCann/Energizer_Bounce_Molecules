using UnityEngine;
using System.Collections;

public class Molecule : MonoBehaviour {
	private Animator _moleculeAnimator;
	
	private float _randomBlickTime = 0;
	private float _decreaseVelocityByFactor = 0;
	private bool _decreaseVelocityByMaterial = false;

	private Vector2 _rollingBandDirection = Vector2.zero;
	private bool _changeVelocityByRollingBand = false;

    void Awake() {
		_moleculeAnimator = GetComponent<Animator>();
		_randomBlickTime = Random.Range(3, 6);
    }

	void Start() {
		StartCoroutine(RandomBlick());

		_decreaseVelocityByMaterial = false;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GetComponent<Rigidbody2D>().angularVelocity = 0;


		GameControler.Instance.MyMolecule = transform;
	}

	void FixedUpdate() {
		if(Mathf.Abs( GetComponent<Rigidbody2D>().angularVelocity) > 0)
			GetComponent<Rigidbody2D>().angularVelocity = Mathf.Lerp(GetComponent<Rigidbody2D>().angularVelocity, 0, Time.deltaTime * 2);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.collider.transform.root.GetComponent<SpriteRenderer>().sortingLayerName == "Obstacles") {
			_moleculeAnimator.SetTrigger("Hit");
			GetComponent<Rigidbody2D>().velocity *= 1.05f;

			GameControler.Instance.CollisionCounter -= 1;
		}

		if(other.collider.GetComponent<Car>()) {
			other.collider.GetComponent<Car>().StopMoving = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.GetComponent<SlowDownMaterial>()) {
			_decreaseVelocityByFactor = other.GetComponent<SlowDownMaterial>().GetFactor;
			_decreaseVelocityByMaterial = true;
			StartCoroutine(DecreaseVelocity());
		}

		if(other.GetComponent<RollingBand>()) {
			_rollingBandDirection = other.transform.up;
			_changeVelocityByRollingBand = true;
			StartCoroutine(ChangeVelocityByRollingBand());
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.GetComponent<SlowDownMaterial>()) {
			_decreaseVelocityByMaterial = false;
		}

		if(other.GetComponent<RollingBand>())	
			_changeVelocityByRollingBand = false;
	}

	IEnumerator RandomBlick() {
		yield return new WaitForSeconds(_randomBlickTime);
		_moleculeAnimator.SetTrigger("Blick");
		_randomBlickTime = Random.Range(3, 6);

		StartCoroutine(RandomBlick());
	}

	IEnumerator DecreaseVelocity() {
		while(_decreaseVelocityByMaterial) {
			GetComponent<Rigidbody2D>().velocity -= GetComponent<Rigidbody2D>().velocity * _decreaseVelocityByFactor;

			if(GetComponent<Rigidbody2D>().velocity.magnitude < 0.1f)
				_decreaseVelocityByMaterial = false;
			yield return 0;
		}
	}

	IEnumerator ChangeVelocityByRollingBand() {
		while(_changeVelocityByRollingBand) {
			GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, _rollingBandDirection * 10, Time.deltaTime * 5.2f);
			yield return 0;
		}
	}
	
	public IEnumerator ResetAfterSmallVelocity() {
		yield return new WaitForSeconds(1);

		while(GetComponent<Rigidbody2D>().velocity.magnitude > 0.1f)
			yield return 0;

		yield return new WaitForSeconds(0.5f);

		if(!GameControler.Instance.IsLevelSuccess)
			GameControler.Instance.ReloadLevel();
	}
}
