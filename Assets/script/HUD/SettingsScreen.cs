using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsScreen : PopUp {

	[SerializeField]
	Text langText;
	// Use this for initialization
	void OnDestroy(){
		LanguageManager.OnLanguageChanged -= OnLanguageChanged;
	}
	void Start () {
		LanguageManager.OnLanguageChanged += OnLanguageChanged;
		OnLanguageChanged ();
	}

	void OnLanguageChanged ()
	{
		langText.text = LanguageManager.current.getText (LanguageNode.Languages) + " : " + LanguageManager.current.currentLanguage.ToString ();
	}
}
