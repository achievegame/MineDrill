using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml;
using Soomla.Store;

public class InAppPurchaseHUDManager : PopUp {

	public GameObject in_Prefab;

	public GameObject gridGroup;
	public Sprite[] chImages = new Sprite[0]; 

	public TextAsset in_Data;//xml data
	List<InAppPurchaseElement> in_ElmentList = new List<InAppPurchaseElement>();


	void Start()
	{ 
		GetCharacters();
	}
	
	public void GetCharacters()
	{
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(in_Data.text); // load the file.
		XmlNodeList in_sList = xmlDoc.GetElementsByTagName("shopElement"); // array of the level nodes.		
		GameObject in_GO;
		InAppPurchaseElement in_Elmnt;
		int i = 0;
		foreach (XmlNode in_Info in in_sList)
		{
			in_GO = (GameObject)Instantiate(in_Prefab);
			in_Elmnt = in_GO.GetComponent<InAppPurchaseElement>();
			in_Elmnt.init(in_Info.Attributes["id"].Value,int.Parse(in_Info.Attributes["index"].Value),LanguageManager.current.getText(in_Info.Attributes["name"].Value),chImages[i++]);
			in_ElmentList.Add(in_Elmnt);
			in_GO.transform.SetParent(gridGroup.transform);
			in_GO.transform.localScale = Vector3.one;
		}
	}	
}
