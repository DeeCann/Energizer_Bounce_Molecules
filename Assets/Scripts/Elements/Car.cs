using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	[SerializeField]
	[Range (0f, 1f)]
	private float _speed = 0;

	[SerializeField]
	[Range (0f, 10f)]
	private float _length = 0;

	private Vector2 _startPosition;
	private Vector2 _direction = Vector2.up;
	private Vector2 _forward;

	private bool _stopMoving;

	void Start () {
		float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
		float sin = Mathf.Sin( angle );
		float cos = Mathf.Cos( angle );
		
		_forward = new Vector2(
			_direction.x * cos - _direction.y * sin,
			_direction.x * sin + _direction.y * cos);

		_startPosition = (Vector2)transform.position;
		StartCoroutine(MoveForward());
	}

	void OnCollisionEnter2D(Collision2D other) {
		StopMoving = true;
	}

	public bool StopMoving {
		set {
			_stopMoving = value;
		}
	}

	IEnumerator MoveForward() {
		if(_stopMoving)
			yield break;

		while(Vector2.Distance(_startPosition, transform.position) < _length) {
			transform.position = (Vector2)transform.position + _forward * _speed * 0.1f;

			if(_stopMoving)
				break;

			yield return 0;
		}
		_startPosition = transform.position;
		StartCoroutine(MoveBackward());
	}

	IEnumerator MoveBackward() {
		if(_stopMoving)
			yield break;

		while(Vector2.Distance(_startPosition, transform.position) < _length) {
			transform.position = (Vector2)transform.position - _forward * _speed * 0.1f;

			if(_stopMoving)
				break;

			yield return 0;
		}
		_startPosition = transform.position;
		StartCoroutine(MoveForward());
	}
}
