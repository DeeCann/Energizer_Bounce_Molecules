using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {
	private Animator _touchlimiter;

	private Vector2 _startForce = Vector2.zero;
	private float _maxForceVelocityFactor = 100;
	private float _startForceVelocityFactor = 1;

	private int _touchMaxTime = 1;
	private float _startTouchTime = 0;

	private bool _ballReleased = false;
	private bool _settingStartParams = false;

	void Start() {
		_touchlimiter = transform.FindChild("TouchLimiter").GetComponent<Animator>();
	}

	void FixedUpdate () {
		if(GameControler.Instance.IsLevelStarted) {
			if(InputEventHandler.IsStartTouchAction && !_settingStartParams) {
				_touchlimiter.SetBool("Play", true);
				_startTouchTime = Time.time;

				_settingStartParams = true;
			}

			if(InputEventHandler.IsEndTouchAction)
				_settingStartParams = false;

			if(InputEventHandler.IsStartTouchAction && !_ballReleased) {
				if(_startTouchTime + _touchMaxTime > Time.time)
					transform.position = Vector2.Lerp(transform.position, InputEventHandler.CurrentTouchPosition, Time.deltaTime * 3);
				else {
					ReleaseAction(InputEventHandler.CurrentTouchPosition);
				}
			}

			if (InputEventHandler.IsEndTouchAction && !_ballReleased) { 
				ReleaseAction(InputEventHandler.EndTouchPosition);
	        }
		}
	}

	public bool IsBallReleased {
		get {
			return _ballReleased;
		}
	}

	private void ReleaseAction(Vector2 _endTouchPosition) {
		_startForce = (_endTouchPosition - (Vector2)transform.position) * 0.5f;
		StartCoroutine(AddStartForce());
		
		_ballReleased = true;
		
		StartCoroutine(GetComponent<Molecule>().ResetAfterSmallVelocity());
		
		_touchlimiter.SetBool("Play", false);
	}

	IEnumerator AddStartForce() {
		while(_startForceVelocityFactor < _maxForceVelocityFactor) {
			GetComponent<Rigidbody2D>().AddForce(_startForce * _startForceVelocityFactor);
			_startForceVelocityFactor += 30;

			yield return 0;
		}
	}
}
