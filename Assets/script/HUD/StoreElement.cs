using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Store;

public class StoreElement : MonoBehaviour {
	//public static event ElementBuy OnElementBuy;

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
	[SerializeField]
	private Text el_desc;

	[HideInInspector]
	public int index;
	[HideInInspector]
	public string id;

	private bool upgrades;
	private ToolType toolType = ToolType.None;

	void OnDestroy(){
		StoreEvents.OnGoodUpgrade -= bought;
	}
	void Start(){
		StoreEvents.OnGoodUpgrade += bought;
	}

	public void init(string id, int index, string name, string desc, ToolType tlType, Sprite img, bool upgrades = true){
		this.index = index;
		this.id = id;
		el_name.text = name;
		el_img.sprite = img;
		this.toolType = tlType;

		this.upgrades = upgrades;
		el_upgradeMeter.gameObject.SetActive (upgrades);
		if (upgrades) {
			int upgdLevel = StoreInventory.GetGoodUpgradeLevel (id);

			if(upgdLevel==5){
				el_desc.text = LanguageManager.current.getText(LanguageNode.FullUpgraded);
				buy.gameObject.SetActive(false);
				el_upgradeMeter.fillAmount = 1f;
			}else{
				el_desc.text = desc;
				el_price.text = AnimineStoreAssets.UPGRADE_PRICE [upgdLevel]+"";
				buy.onClick.AddListener(()=>{
					_OnElementBuy();
				});
			}
			el_upgradeMeter.fillAmount = upgdLevel / 5f;

		} else {
			el_desc.text = desc;
			el_price.text = AnimineStoreAssets.TOOLS_PRICE[(int)toolType]+"";
			buy.onClick.AddListener(()=>{
				_OnElementBuy();
			});
		}			
	}

	void _OnElementBuy ()
	{
		if (upgrades) {
			int upgdLevel = StoreInventory.GetGoodUpgradeLevel (id);
			if(StoreInventory.GetItemBalance(AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID)>=AnimineStoreAssets.UPGRADE_PRICE[upgdLevel]){
				StoreInventory.UpgradeGood(id);			
			}
		} else {
			if (StoreInventory.CanAfford (id) && StoreInventory.GetItemBalance(id) <5) {
				//MAudioManager.current.PlayFx (AudioName.PurchaseClick);
				StoreInventory.BuyItem (id);
			}
		}
	}

	void bought(VirtualGood arg1, UpgradeVG arg2) {
		if (upgrades) {
			int upgdLevel = StoreInventory.GetGoodUpgradeLevel (id);
			if(upgdLevel==5){
				el_desc.text = LanguageManager.current.getText(LanguageNode.FullUpgraded);
				buy.gameObject.SetActive(false);
				el_upgradeMeter.fillAmount = 1f;
			}else{
				el_upgradeMeter.fillAmount = upgdLevel / 5f;
				el_price.text = AnimineStoreAssets.UPGRADE_PRICE [upgdLevel]+"";
			}

		} 
	}
}
