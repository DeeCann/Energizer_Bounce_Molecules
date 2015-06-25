using UnityEngine;
using System.Collections;

public class BottomMenuControler : MonoBehaviour {
	[SerializeField]
	private Transform _tapHint;

	[SerializeField]
	private Transform _selectMoleculePanel;

	private bool _selectMoleculePanelActive = false;

	public void OpenMoleculeChoosePanel() {
		if(_selectMoleculePanelActive) {
			_selectMoleculePanel.GetComponent<Animator>().SetInteger("Active", 0);
			//_selectMoleculePanel.gameObject.SetActive(false);
			_selectMoleculePanelActive = false;
		} else {
			_selectMoleculePanel.gameObject.SetActive(true);
			_selectMoleculePanel.GetComponent<Animator>().SetInteger("Active", 1);
			_selectMoleculePanelActive = true;

			_tapHint.gameObject.SetActive(false);
		}
	}
}
