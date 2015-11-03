using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Store;

public class VirtualMoneyIndicator : MonoBehaviour {
	public static VirtualMoneyIndicator current;
	[SerializeField]
	private Text goldFish;
	[SerializeField]
	private Text heart;

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

//	void OnEnable(){
//		setIt ();
//	}

	private void OnCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance,int amountAdded) {
		setIt ();
	}

	void setIt(){
		goldFish.text = ""+StoreInventory.GetItemBalance (AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID);
		//heart.text = ""+StoreInventory.GetItemBalance (AnimineStoreAssets.HEART_VC_ITEM_ID);
	}
}
