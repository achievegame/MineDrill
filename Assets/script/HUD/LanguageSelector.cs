using UnityEngine;
using System.Collections;

public class LanguageSelector : MonoBehaviour {

	[SerializeField]
	private ToggleButton[] langBtn;
	public void setLanguage(int ln){
		foreach(ToggleButton tBtn in langBtn){
			tBtn.isOn = false;
		}

		langBtn [ln].isOn = true;

		LanguageManager.current.setLanguage (ln);
	}

	void Start(){
		Debug.Log ("currentL:"+LanguageManager.current.currentLanguage);
		langBtn[(int)LanguageManager.current.currentLanguage].isOn = true;
	}

	void setCurrentLanguage(){

	}

}
