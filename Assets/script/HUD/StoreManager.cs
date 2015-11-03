using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml;
using Soomla.Store;

public class StoreManager : PopUp {

	public GameObject[] ELEPrefab;

	public GameObject gridGroup;
	public Sprite[] ElEImages = new Sprite[0]; 

	public TextAsset ELEData;//xml data
	List<StoreElement> elmentList = new List<StoreElement>();


	void Start()
	{ 
		MakeList();
	}
	
	public void MakeList()
	{
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(ELEData.text); // load the file.
		XmlNodeList EleList = xmlDoc.GetElementsByTagName("storeElement"); // array of the level nodes.		
		GameObject eleGO;
		StoreElement strElmnt;
		int i = 0;
		foreach (XmlNode eleInfo in EleList)
		{
			int pfI = int.Parse(eleInfo.Attributes["storeType"].Value);
			eleGO = (GameObject)Instantiate(ELEPrefab[pfI]);
			if(pfI==0){
				Text txtEl = eleGO.GetComponent<Text>();
				txtEl.text = LanguageManager.current.getText(eleInfo.Attributes["name"].Value);
			}else if(pfI==1){
				strElmnt = eleGO.GetComponent<StoreElement>();
				strElmnt.init(
					eleInfo.Attributes["id"].Value,
					i,
					LanguageManager.current.getText(eleInfo.Attributes["name"].Value),
					eleInfo.Attributes["price"].Value,
					ElEImages[int.Parse(eleInfo.Attributes["imageIndex"].Value)],
					(eleInfo.Attributes["upgrades"] != null)
				);
				elmentList.Add(strElmnt);
			}


			eleGO.transform.SetParent(gridGroup.transform);
			eleGO.transform.localScale = Vector3.one;

		}
	}	
}
