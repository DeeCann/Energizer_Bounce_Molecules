using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewMolecule : MonoBehaviour {
	public Sprite plastic;
	public Sprite gel;
	public Sprite iron;
	public Sprite rubber;
	public Sprite wood;

	private static NewMolecule _instance = null;
	public static NewMolecule Instance {
		get {
			if (_instance == null)
				_instance = GameObject.FindObjectOfType(typeof(NewMolecule)) as NewMolecule;
			
			return _instance;
		}
	}
	
	void Awake () {
		_instance = this;
	}

	void Update(){}

	public void ShowNewMolecule(string molecule) {
		switch(molecule) {
			case "plastic":
				transform.FindChild("Molecule").GetComponent<Image>().sprite = plastic;
				break;
			case "gel":
				transform.FindChild("Molecule").GetComponent<Image>().sprite = gel;
				break;
			case "iron":
				transform.FindChild("Molecule").GetComponent<Image>().sprite = iron;
				break;
			case "rubber":
				transform.FindChild("Molecule").GetComponent<Image>().sprite = rubber;
				break;
			case "wood":
				transform.FindChild("Molecule").GetComponent<Image>().sprite = wood;
				break;
		}

		SFXControler.Instance.VolumeDown();
		GetComponent<Animator>().SetBool("Play", true);
		GetComponent<AudioSource>().Play();
	}
}
