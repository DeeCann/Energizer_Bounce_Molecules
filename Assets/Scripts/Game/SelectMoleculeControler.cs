using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectMoleculeControler : MonoBehaviour {
	
	public Image plasticMolecule;
	public Sprite plasticSprite;
	
	public Image gelMolecule;
	public Sprite gelSprite;

	public Image ironMolecule;
	public Sprite ironSprite;


	public Image rubberMolecule;
	public Sprite rubberSprite;

	public Image woodMolecule;
	public Sprite woodSprite;

	void Start() {
		if(PlayerPrefs.HasKey("plastic"))
			plasticMolecule.GetComponent<Image>().sprite = plasticSprite;

		if(PlayerPrefs.HasKey("iron"))
			ironMolecule.GetComponent<Image>().sprite = ironSprite;

		if(PlayerPrefs.HasKey("gel"))
			gelMolecule.GetComponent<Image>().sprite = gelSprite;

		if(PlayerPrefs.HasKey("rubber"))
			rubberMolecule.GetComponent<Image>().sprite = rubberSprite;

		if(PlayerPrefs.HasKey("wood"))
			woodMolecule.GetComponent<Image>().sprite = woodSprite;
	}

	public void SelectMe(string _name) {
		if(!InputEventHandler._isEndTouchAction && GameControler.Instance.ChangeMolecule(_name)) {
			GetComponent<AudioSource>().Play();
			BottomMenuControler.Instance.OpenMoleculeChoosePanel();

			PlayerPrefs.SetString("LastMoleculeSelected", _name);
		}
	}
}
