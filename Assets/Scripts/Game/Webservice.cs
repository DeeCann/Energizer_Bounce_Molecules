using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Webservice : MonoBehaviour {

	public InputField Code;
	public Text ErrorMsg;
	public Image AlertImage;

	private string _errMessage = "Your code has been already used,\nor is incorrect";
	
	public void Send() {
		if(!IsCodeCorrect) {
			ErrorMsg.text = _errMessage;
			AlertImage.enabled = true;
			Debug.Log(Code.text);
		} else 
			UnlockAllLevelsPanel.Instance.SuccessCodeUnlockPanel();


	}

	private bool IsCodeCorrect {
		get {
			if(Code.text == "123")
				return true;
			else
				return false;
		}
	}
}
