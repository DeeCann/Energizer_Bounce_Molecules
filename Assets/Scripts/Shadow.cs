using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour {

	public Color ShadowColor = new Color(0.1f, 0.1f, 0.1f, 0.1f);
	public Vector2 ShadowOffset = Vector3.one;

	void Start () {
		GameObject shadow = new GameObject();
		SpriteRenderer shadowSprite = shadow.AddComponent<SpriteRenderer>();
		shadowSprite.sprite = GetComponent<SpriteRenderer>().sprite;
		shadowSprite.color = ShadowColor;
		shadow.transform.position = (Vector2)transform.position - ShadowOffset * 0.1f;
		shadow.transform.parent = transform;

		shadow.transform.localScale = Vector2.one;
		shadow.transform.rotation = transform.rotation;
	}
}
