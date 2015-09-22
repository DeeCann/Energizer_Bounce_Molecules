using UnityEngine;
using System.Collections;

public class MaxLevelBounce : MonoBehaviour {
	
	[SerializeField]
	private int _maxBounce = 3;
	
	void Start () {	
		if(System.Convert.ToInt16( Application.loadedLevelName.Substring(6)) == 11) {
			if(PlayerPrefs.HasKey("UnlockMaxBounce"))
				GameControler.Instance.CollisionCounter = PlayerPrefs.GetInt("UnlockMaxBounce");
			else
				GameControler.Instance.CollisionCounter = 0;
		} else 
			GameControler.Instance.CollisionCounter = _maxBounce;
	}

	void Update () {		
		if(_maxBounce < 0)
			GameControler.Instance.LevelFailed();
	}
}
