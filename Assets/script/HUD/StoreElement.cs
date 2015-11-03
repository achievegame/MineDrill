using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Store;

public class StoreElement : MonoBehaviour {
	//public static event listElementHUDChanged OnElementBuy;

	[SerializeField]
	private Text el_name;
	[SerializeField]
	private Text el_price;
	[SerializeField]
	private Image el_img;
	[SerializeField]
	private Button buy;
	[SerializeField]
	private UpgradeMeter el_upgradeMeter; 

	[HideInInspector]
	public int index;
	[HideInInspector]
	public string id;

	public void init(string id, int index, string name, string price, Sprite img, bool upgrades = true){
		this.index = index;
		this.id = id;
		el_name.text = name;
		el_price.text = price;
		el_img.sprite = img;
		buy.onClick.AddListener(()=>{
				OnElementBuy();
		});

		el_upgradeMeter.gameObject.SetActive (upgrades);
	}

	void OnElementBuy ()
	{
		if (StoreInventory.CanAfford (id)) {
//			MAudioManager.current.PlayFx (AudioName.PurchaseClick);
			StoreInventory.BuyItem (id);
			bought ();
		}
//		} else {
//			GameObject.FindGameObjectWithTag(Constants.TAG_HUD).GetComponent<HUD>().OpenMenu((int) MenuState.Shop_GoldFishMenu);
//		}
	}

	void bought(){

	}
}
