using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Store;

public class InAppPurchaseElement : MonoBehaviour {

	[SerializeField]
	private Text in_name;
	[SerializeField]
	private Text in_price;
	[SerializeField]
	private Image in_img;
	[SerializeField]
	private Button buy;
	[SerializeField]
	private Text in_coin_count;


	[HideInInspector]
	public int index;
	[HideInInspector]
	public string id;

	public void init(string id, int index, string name, Sprite img){
		this.index = index;
		this.id = id;
		//this.heroIndex = heroIndex;
		in_name.text = name;
		in_coin_count.text = AnimineStoreAssets.INAPP_COIN_AMOUNT[index]+""+LanguageManager.current.getText(LanguageNode.Coins);
		in_price.text = "$ "+AnimineStoreAssets.INAPP_PRICE[index]+"";
		in_img.sprite = img;
		buy.onClick.AddListener(()=>{
				OnElementBuy();
		});
	}

	void OnElementBuy ()
	{
		StoreInventory.BuyItem (id);
	}
}
