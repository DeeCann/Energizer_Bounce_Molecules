using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {
	private LineRenderer _lineHelper;

	private bool _ballReleased = false;
	private bool _settingDirection = false;

	void Start() {
		_lineHelper = GetComponent<LineRenderer>();
	}

	void FixedUpdate () {
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
			GetComponent<Rigidbody2D>().AddForce((InputEventHandler.EndTouchPosition - (Vector2)transform.position) * 300);

			_ballReleased = true;
        }
	}
}
