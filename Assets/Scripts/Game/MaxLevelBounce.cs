using UnityEngine;
using System.Collections;

public class MaxLevelBounce : MonoBehaviour {
	
	[SerializeField]
	private int _maxBounce = 3;
	
	void Start () {	
		GameControler.Instance.CollisionCounter = _maxBounce;
	}

	void Update () {		
		if(_maxBounce < 0)
			GameControler.Instance.LevelFailed();
	}
}
