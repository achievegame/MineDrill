using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Store;
using Soomla.Levelup;

public class AnimineStoreAssets : IStoreAssets
{


	public int GetVersion ()
	{
		return 0;
	}

	public VirtualCurrency[] GetCurrencies ()
	{
		return new VirtualCurrency[]{GOLD_COIN_VC, HEART_VC};
	}

	public VirtualGood[] GetGoods ()
	{
		return new VirtualGood[] {
			DYNAMITE_VG,
			DRILLER_VG,
			FAN_VG,
			BATTERY_VG,
			BAG_VG,
			PIGGY_VG,
			COW_VG,
			BEARRY_VG,
			TIGEY_VG,
			DRAGGY_VG
		};
	}

	public VirtualCurrencyPack[] GetCurrencyPacks ()
	{
		return new VirtualCurrencyPack[] {
			NET_OF_FISH_VCP,
			BAG_OF_FISH_VCP,
			BOWL_OF_FISH_VCP,
			TANK_OF_FISH_VCP,
			POND_OF_FISH_VCP,
			ROUND_OF_HEARTS_VCP,
			BOX_OF_HEARTS_VCP,
			CHEST_OF_HEARTS_VCP
		};
	}

	public VirtualCategory[] GetCategories ()
	{
		return new VirtualCategory[]{GENERAL_CATEGORY};
	}

	/*** static final members  **/
	public const string GOLD_COIN_VC_ITEM_ID = "GoldCoinVC";
	public const string HEART_VC_ITEM_ID = "HeartVC";

	public const string DYNAMITE_VG_ITEM_ID = "dynamite_vg";
	public const string DRILLER_VG_ITEM_ID = "driller_vg";
	public const string FAN_VG_ITEM_ID = "fan_vg";
	public const string BATTERY_VG_ITEM_ID = "battery_vg";
	public const string BAG_VG_ITEM_ID = "bag_vg";
	public const string PIGGY_VG_ITEM_ID = "piggy_vg";
	public const string COW_VG_ITEM_ID = "cow_vg";
	public const string BEARRY_VG_ITEM_ID = "bearry_vg";
	public const string TIGEY_VG_ITEM_ID = "tigey_vg";
	public const string DRAGGY_VG_ITEM_ID = "draggy_vg";

	public static VirtualCurrency GOLD_COIN_VC = new VirtualCurrency (
		"GoldCoin",
		"Coin Currency",
		GOLD_COIN_VC_ITEM_ID 
	);

	VirtualCurrency HEART_VC = new VirtualCurrency (
		"Heart",
		"Heart Currency",
		HEART_VC_ITEM_ID
	);

	//virtual currency pack	
	public static VirtualCurrencyPack NET_OF_FISH_VCP = new VirtualCurrencyPack (
		"net of fish",
		"",
		"net_of_fish_vcp",
		7500,
		GOLD_COIN_VC_ITEM_ID,
		new PurchaseWithMarket (
		"com.shnappy.net_of_fish",
		1.99)
	);
	public static VirtualCurrencyPack BAG_OF_FISH_VCP = new VirtualCurrencyPack (
		"bag of fish",
		"",
		"bag_of_fish_vcp",
		15000,
		GOLD_COIN_VC_ITEM_ID,
		new PurchaseWithMarket (
		"com.shnappy.bag_of_fish",
		2.99)
	);
	public static VirtualCurrencyPack BOWL_OF_FISH_VCP = new VirtualCurrencyPack (
		"bowl of fish",
		"",
		"bowl_of_fish_vcp",
		45000,
		GOLD_COIN_VC_ITEM_ID,
		new PurchaseWithMarket (
		"com.shnappy.bowl_of_fish",
		7.99)
	);
	public static VirtualCurrencyPack TANK_OF_FISH_VCP = new VirtualCurrencyPack (
		"tank of fish",
		"",
		"tank_of_fish_vcp",
		90000,
		GOLD_COIN_VC_ITEM_ID,
		new PurchaseWithMarket (
		"com.shnappy.tank_of_fish",
		11.99)
	);
	public static VirtualCurrencyPack POND_OF_FISH_VCP = new VirtualCurrencyPack (
		"pond of fish",
		"",
		"pond_of_fish_vcp",
		180000,
		GOLD_COIN_VC_ITEM_ID,
		new PurchaseWithMarket (
		"com.shnappy.pond_of_fish",
		21.99)
	);
	VirtualCurrencyPack ROUND_OF_HEARTS_VCP = new VirtualCurrencyPack (
		"round of hearts",
		"",
		"round_of_hearts_vcp",
		10,
		"HeartVC",
		new PurchaseWithMarket (
		"com.shnappy.round_of_hearts",
		2.99)
	);
	VirtualCurrencyPack BOX_OF_HEARTS_VCP = new VirtualCurrencyPack (
		"box of hearts",
		"",
		"box_of_hearts_vcp",
		50,
		"HeartVC",
		new PurchaseWithMarket (
		"com.shnappy.box_of_hearts",
		12.99)
	);
	VirtualCurrencyPack CHEST_OF_HEARTS_VCP = new VirtualCurrencyPack (
		"chest of hearts",
		"",
		"chest_of_hearts_vcp",
		250,
		"HeartVC",
		new PurchaseWithMarket (
		"com.shnappy.chest_of_hearts",
		35.99)
	);

	//virtual goods
	public static VirtualGood DYNAMITE_VG = new SingleUseVG (
		"dynamite",
		"",
		DYNAMITE_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		1500)
	);
	//public static VirtualGood DYNAMITE_VG_U1 = new UpgradeVG(
	public static VirtualGood DRILLER_VG = new SingleUseVG (
		"driller",
		"",
		DRILLER_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		600)
	);
	public static VirtualGood FAN_VG = new SingleUseVG (
		"fan",
		"",
		FAN_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		600)
	);
	public static VirtualGood BATTERY_VG = new SingleUseVG (
		"battery",
		"",
		BATTERY_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		600)
	);
	public static VirtualGood BAG_VG = new SingleUseVG (
		"bag",
		"",
		BAG_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		600)
	);
	public static VirtualGood PIGGY_VG = new EquippableVG (
		EquippableVG.EquippingModel.GLOBAL,
		"Piggy",
		"",
		PIGGY_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		30000)
	);
	public static VirtualGood COW_VG = new EquippableVG (
		EquippableVG.EquippingModel.GLOBAL,
		"Cow",
		"",
		COW_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		45000)
	);
	public static VirtualGood BEARRY_VG = new EquippableVG (
		EquippableVG.EquippingModel.GLOBAL,
		"Bearry",
		"",
		BEARRY_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		60000)
	);
	public static VirtualGood TIGEY_VG = new EquippableVG (
		EquippableVG.EquippingModel.GLOBAL,
		"Tigey",
		"",
		TIGEY_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		90000)
	);
	public static VirtualGood DRAGGY_VG = new EquippableVG (
		EquippableVG.EquippingModel.GLOBAL,
		"Draggy",
		"",
		DRAGGY_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		120000)
	);

	//virtual category
	public static VirtualCategory GENERAL_CATEGORY = new VirtualCategory ("generalCategory", new List<string> (new string[] {
		DYNAMITE_VG_ITEM_ID,DRILLER_VG_ITEM_ID,FAN_VG_ITEM_ID,BATTERY_VG_ITEM_ID,BAG_VG_ITEM_ID,PIGGY_VG_ITEM_ID,COW_VG_ITEM_ID,BEARRY_VG_ITEM_ID,TIGEY_VG_ITEM_ID,
	DRAGGY_VG_ITEM_ID}));

	//equipable model

}
