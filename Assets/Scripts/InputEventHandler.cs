using UnityEngine;
using System.Collections;

public class InputEventHandler : MonoBehaviour {
	public static bool _isStartTouchAction = false;
	public static bool _isEndTouchAction = false;
	private static Vector2 _startTouchPosition = Vector2.zero;
	private static Vector2 _currentTouchPosition = Vector2.zero;
	private static Vector2 _endTouchPosition = Vector2.zero;

	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			_startTouchPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			_isStartTouchAction = true;
		}

		if(_isStartTouchAction){
			_currentTouchPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		}

		if(Input.GetMouseButtonUp(0)) {
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
