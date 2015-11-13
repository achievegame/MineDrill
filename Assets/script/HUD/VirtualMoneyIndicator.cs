using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Store;

public class VirtualMoneyIndicator : PopUp {
	public static VirtualMoneyIndicator current;
	[SerializeField]
	private Text coinCount;

	void Awake(){
		current = this;
		//SetActive (false);
	}

	void OnDestroy(){
		StoreEvents.OnCurrencyBalanceChanged -= OnCurrencyBalanceChanged;
	}

	void Start(){
		StoreEvents.OnCurrencyBalanceChanged += OnCurrencyBalanceChanged;

		setIt ();
	}


	private void OnCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance,int amountAdded) {
		setIt ();
	}

	void setIt(){
		coinCount.text = ""+StoreInventory.GetItemBalance (AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID);
	}

	public void OpenShop(){
		LoadHUD (Constants.HUD_SHOP);
	}
}
