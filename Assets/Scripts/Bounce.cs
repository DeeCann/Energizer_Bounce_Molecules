using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {
	private LineRenderer _lineHelper;

	private Vector2 _startForce = Vector2.zero;
	private float _maxForceVelocityFactor = 100;
	private float _startForceVelocityFactor = 1;

	private bool _ballReleased = false;
	private bool _settingDirection = false;

	void Start() {
		_lineHelper = GetComponent<LineRenderer>();
	}

	void FixedUpdate () {
		if(GameControler.Instance.IsLevelStarted) {
			if(InputEventHandler.IsStartTouchAction)
				_settingDirection = true;

			if(InputEventHandler.IsEndTouchAction)
				_settingDirection = false;

			if(_settingDirection) {
				_lineHelper.SetVertexCount(2);
				_lineHelper.SetPosition(0, transform.position);
				_lineHelper.SetPosition(1, InputEventHandler.CurrentTouchPosition);
			}
			else
				_lineHelper.SetVertexCount(0);

			if (InputEventHandler.IsEndTouchAction && !_ballReleased) { 
				_startForce = InputEventHandler.EndTouchPosition - (Vector2)transform.position;

				//if(_startForce.magnitude > 3.8f)
				//	_startForce = _startForce.normalized;

				StartCoroutine(AddStartForce());

				_ballReleased = true;

				StartCoroutine(GetComponent<Molecule>().ResetAfterSmallVelocity());
	        }
		}
	}

	public bool IsBallReleased {
		get {
			return _ballReleased;
		}
	}

	IEnumerator AddStartForce() {
		while(_startForceVelocityFactor < _maxForceVelocityFactor) {
			GetComponent<Rigidbody2D>().AddForce(_startForce * _startForceVelocityFactor);
			_startForceVelocityFactor += 30;

			yield return 0;
		}
	}
}
