using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour {
	
	void Start () {
		GameObject shadow = new GameObject();
		SpriteRenderer shadowSprite = shadow.AddComponent<SpriteRenderer>();
		shadowSprite.sprite = GetComponent<SpriteRenderer>().sprite;
		shadowSprite.color = new Color(0.1f, 0.1f, 0.1f, 0.1f);
		shadow.transform.position = transform.position - Vector3.one * 0.1f;
		shadow.transform.parent = transform;

		shadow.transform.localScale = Vector2.one;
		shadow.transform.rotation = transform.rotation;
	}
}
