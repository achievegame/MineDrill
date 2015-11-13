using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Store;

public class SettingsScreen : PopUp {

	[SerializeField]
	Text langText;
	[SerializeField]
	Toggle musicBtn;
	[SerializeField]
	Toggle soundBtn;
	// Use this for initialization
	void OnDestroy(){
		LanguageManager.OnLanguageChanged -= OnLanguageChanged;
	}
	void Start () {
		LanguageManager.OnLanguageChanged += OnLanguageChanged;
		OnLanguageChanged ();
		musicBtn.isOn = MAudioManager.current.IsMusicOn;
		soundBtn.isOn = MAudioManager.current.IsSoundOn;
	}

	public void setMusic(bool value){
		Debug.Log ("music value:"+value);
		MAudioManager.current.IsMusicOn = musicBtn.isOn;
	}
	public void setSound(bool value){
		MAudioManager.current.IsSoundOn = soundBtn.isOn;
	}

	public void RestorePurchase(){
		if(!SoomlaStore.TransactionsAlreadyRestored())
			SoomlaStore.RestoreTransactions();
	}

	void OnLanguageChanged ()
	{
		langText.text = LanguageManager.current.getText (LanguageNode.Languages) + " : " + LanguageManager.current.currentLanguage.ToString ();
	}
}
