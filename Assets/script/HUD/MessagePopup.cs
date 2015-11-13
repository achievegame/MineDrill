using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessagePopup : PopUp {
	[SerializeField]
	private Text messageTxt;
	public void SetText(string txt){
		messageTxt.text = txt;
	}
}
