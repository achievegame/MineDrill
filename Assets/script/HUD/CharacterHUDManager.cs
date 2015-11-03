using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml;
using Soomla.Store;

public class CharacterHUDManager : MonoBehaviour {

	public GameObject CHRPrefab;

	public GameObject gridGroup;
	public Sprite[] chImages = new Sprite[0]; 

	public TextAsset chrData;//xml data
	List<CharacterElement> chrElmentList = new List<CharacterElement>();


	void Start()
	{ 
		GetCharacters();
	}

	void OnDestroy(){
		CharacterElement.OnCharacterChanged -= OnCharacterChanged;
	}
	
	public void GetCharacters()
	{
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(chrData.text); // load the file.
		XmlNodeList chrsList = xmlDoc.GetElementsByTagName("chr"); // array of the level nodes.		
		GameObject chrGO;
		CharacterElement chrElmnt;
		int i = 0;
		foreach (XmlNode chrInfo in chrsList)
		{
			chrGO = (GameObject)Instantiate(CHRPrefab);
			chrElmnt = chrGO.GetComponent<CharacterElement>();
			chrElmnt.init(chrInfo.Attributes["id"].Value,i,LanguageManager.current.getText(chrInfo.Attributes["name"].Value),chrInfo.Attributes["price"].Value,chImages[i++]);
			chrElmentList.Add(chrElmnt);
			chrGO.transform.SetParent(gridGroup.transform);
			chrGO.transform.localScale = Vector3.one;
		}
		CharacterElement.OnCharacterChanged += OnCharacterChanged;
	}

	void OnCharacterChanged(int index){
		foreach (CharacterElement chrElmnt in chrElmentList) {
			chrElmnt.selectIt();	
		}
		//MAudioManager.current.PlayFx (AudioName.MenuClick);
	}
	
}
