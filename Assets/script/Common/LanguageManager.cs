using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour {
	public static LanguageManager current;
	const string LANG_KEY = "lang_key";
	TextAsset xmlData;
	XmlDocument xmlDoc;
	XmlNodeList dataList;

	Font fnt;
	string[] fontName = {"CarterOne","ArialBold","ArialBold","ArialBold","ArialBold","ArialBold","ArialBold"};

	public static event LanguageChanged OnLanguageChanged;

	void Awake(){	
		if (current == null) {
			current = this;

			xmlDoc = new XmlDocument ();

			setLanguage (currentLanguage);
		
		} else if (current != this) {
			Destroy (gameObject);	
		}
	}

	public void setLanguage(int langI){
		setLanguage ((Lang) langI);
	}

	public void setLanguage(string langS){
		setLanguage ((Lang) System.Enum.Parse(typeof(Lang),langS));
	}

	public void setLanguage(Lang lang){
		xmlData = Resources.Load<TextAsset> ("language/"+lang.ToString());		
		xmlDoc.LoadXml (xmlData.text);
		dataList = xmlDoc.GetElementsByTagName ("string");

		//making language node
		//makingLanguageNode ();


		PlayerPrefs.SetString (LANG_KEY, lang.ToString ());

		//set font
		fnt = Resources.Load<Font> ("font/"+fontName[(int)lang]);

		if (OnLanguageChanged != null) {
			OnLanguageChanged();
		}
	}

	public string getText(string langNode){
		return getText ((LanguageNode)System.Enum.Parse (typeof(LanguageNode), langNode));
	}

	public string getText(LanguageNode langNode){
		if (dataList == null)
			return "";
		return dataList.Item ((int)langNode).InnerText;
	}

	public Font getFont(){
		return fnt;
	}

	public Lang currentLanguage{
		get{
			string langS = PlayerPrefs.GetString (LANG_KEY, Lang.EN.ToString());
			return (Lang)System.Enum.Parse (typeof(Lang), langS);
		}
	}


	//making 
	private void makingLanguageNode(){
		string nodeS = "";
		foreach (XmlNode info in dataList) {
			nodeS+= info.Attributes[0].Value+",\n";
		}
		Debug.Log (nodeS);	
	}



}
public enum Lang{
	EN,
	JA,
	KO,
	ES,
	ZH,
	FR,
	RU
}


public enum Language{
	English,
	Japanese,
	Korian,
	Spanish,
	Chinese,
	French,
	Russian
}

public enum LanguageTextType{
	Text_Normal,
	Text_Urgent,
	Text_Ignore,
	Text_Ignore_Urgent
}

public enum LanguageNode{
	Test,
	New,
	Bag,
	Heroes,
	Mission,
	Earn,
	EarnCoins,
	Leaderboard,
	Connect,
	Settings,
	Languages,
	Scores,
	Driller,
	Battery,
	Dynamite,
	Fan,
	Add,
	SingleUse,
	Upgrades,
	GetNCoins,
	Play,
	Pause,
	Paused,
	Minerals,
	GameOver,
	StackOfCoins,
	PileOfCoins,
	BagOfCoins,
	ChestOfCoins,
	VaultOfCoins,
	Buy,
	Skip,
	SkipMission,
	MissionCompleted,
	Prize,
	Reward,
	Select,
	Selected,
	Congratulations,
	Shop,
	BurstMode,
	Stone,
	Coal,
	Copper,
	Iron,
	Silver,
	Emerald,
	Gold,
	Ruby,
	Diamond,
	Piggy,
	Cowy,
	Bearry,
	Tigey,
	Draggy,
	English,
	Japanese,
	Korean,
	Spanish,
	Chinese,
	French,
	Russian
}
