using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Store;

public class CharacterElement : MonoBehaviour {
	//public static event listElementHUDChanged OnElementBuy;
	public static event characterChanged OnCharacterChanged;

	[SerializeField]
	private Text ch_name;
	[SerializeField]
	private Text ch_price;
	[SerializeField]
	private Image ch_img;
	[SerializeField]
	private Button buy;
	[SerializeField]
	private Button select;
	[SerializeField]
	private GameObject selectedLabel;

	[HideInInspector]
	public int index;
	[HideInInspector]
	public string id;

	//private int heroIndex;

	public void init(string id, int index, string name, int heroIndex, Sprite img){
		this.index = index;
		this.id = id;
		//this.heroIndex = heroIndex;
		ch_name.text = name;
		ch_price.text = AnimineStoreAssets.HEROS_PRICE[heroIndex]+"";
		ch_img.sprite = img;
		buy.onClick.AddListener(()=>{
				OnElementBuy();
		});
		select.onClick.AddListener(()=>{
			OnEquip();
		});

		if (StoreInventory.GetItemBalance (id) > 0) {
			ch_price.gameObject.SetActive (false);
			buy.gameObject.SetActive(false);
			bool selected = StoreInventory.IsVirtualGoodEquipped (id);
			selectedLabel.SetActive (selected);
			select.gameObject.SetActive (!selected);
			//if(selected)
				//GameControl.current.CharacterChanged (index);
		}


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
		buy.gameObject.SetActive(false);
		ch_price.gameObject.SetActive (false);
		selectedLabel.SetActive (true);
		OnEquip ();
	}



	void OnEquip(){
		StoreInventory.EquipVirtualGood (id);
		GameControl.current.CharacterChanged (index);
		if(OnCharacterChanged!=null)
			OnCharacterChanged(index);
	}

	public void selectIt(){
		if (StoreInventory.GetItemBalance (id) > 0) {
			bool selected = StoreInventory.IsVirtualGoodEquipped (id);
			selectedLabel.SetActive (selected);
			select.gameObject.SetActive (!selected);
		}
	}
}
