using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InputEventHandler : MonoBehaviour {
	public static bool _isStartTouchAction = false;
	public static bool _isEndTouchAction = false;
	private static Vector2 _startTouchPosition = Vector2.zero;
	private static Vector2 _currentTouchPosition = Vector2.zero;
	private static Vector2 _endTouchPosition = Vector2.zero;

	private bool _UIHit = false;

	void Awake() {
		_isStartTouchAction = false;
		_isEndTouchAction = false;

		_startTouchPosition = Vector2.zero;
		_currentTouchPosition = Vector2.zero;
		_endTouchPosition = Vector2.zero;
	}


	void Update () {
		if(EventSystem.current.IsPointerOverGameObject(0) || EventSystem.current.IsPointerOverGameObject(1)) {
			_UIHit = true;

			return;
		}
		
		if((Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor) && EventSystem.current.IsPointerOverGameObject(-1)) {
			_UIHit = true;

			return;
		}

		if(Input.GetMouseButtonDown(0)) {
			_UIHit = false;	
			_startTouchPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			_isStartTouchAction = true;
		}

		if(_isStartTouchAction) {
			_currentTouchPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		}

		if(Input.GetMouseButtonUp(0) && _isStartTouchAction) {
			if(_UIHit) {
				_UIHit = false;
				return;
			}

			_endTouchPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			_isStartTouchAction = false;
			_isEndTouchAction = true;
		}
	}

	public static Vector2 StartTouchPosition
	{
		get {
			return _startTouchPosition;
		}
	}

	public static Vector2 CurrentTouchPosition
	{
		get {
			return _currentTouchPosition;
		}
	}
	public static Vector2 EndTouchPosition
	{
		get {
			return _endTouchPosition;
		}
	}

	public static bool IsStartTouchAction
	{
		get {
			return _isStartTouchAction;
		}
	}

	public static bool IsEndTouchAction
	{
		get {
			return _isEndTouchAction;
		}
	}
}
