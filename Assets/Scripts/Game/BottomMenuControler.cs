using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BottomMenuControler : MonoBehaviour {
	[SerializeField]
	private Transform _tapHint;

	[SerializeField]
	private Transform _selectMoleculePanel;

	[SerializeField]
	private Text _maxColisionsText;

	private bool _selectMoleculePanelActive = false;

	private static BottomMenuControler _instance = null;
	public static BottomMenuControler Instance {
		get {
			if (_instance == null)
				_instance = GameObject.FindObjectOfType(typeof(BottomMenuControler)) as BottomMenuControler;
			
			return _instance;
		}
	}

	void Awake() {
		_instance = this;

		if(PlayerPrefs.HasKey("MoleculeHint"))
			_tapHint.gameObject.SetActive(false);
	}

	void Update() {
		_maxColisionsText.text = MoleculeCounterToString;
	}

	public void OpenMoleculeChoosePanel() {
		if(InputEventHandler._isEndTouchAction)
			return;

		PlayerPrefs.SetInt("MoleculeHint", 1);

		transform.FindChild("ChooseMolecule").GetComponent<AudioSource>().Play();

		if(_selectMoleculePanelActive) {
			_selectMoleculePanel.GetComponent<Animator>().SetInteger("Active", 0);
			_selectMoleculePanel.gameObject.SetActive(false);
			_selectMoleculePanelActive = false;
		} else {
			_selectMoleculePanel.gameObject.SetActive(true);
			_selectMoleculePanel.GetComponent<Animator>().SetInteger("Active", 1);
			_selectMoleculePanelActive = true;

			_tapHint.gameObject.SetActive(false);
		}
	}

	private string MoleculeCounterToString {
		get {
			if(GameControler.Instance.CollisionCounter <= 9)
				return "0"+GameControler.Instance.CollisionCounter.ToString();
			else
				return GameControler.Instance.CollisionCounter.ToString();
		}
	}
}
