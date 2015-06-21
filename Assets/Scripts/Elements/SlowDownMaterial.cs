using UnityEngine;
using System.Collections;

public class SlowDownMaterial : MonoBehaviour {

	[SerializeField]
	[Range (0f, 1f)]
	private float _slowDownFactor = 0;

	public float GetFactor {
		get {
			return _slowDownFactor;
		}

	}
}
