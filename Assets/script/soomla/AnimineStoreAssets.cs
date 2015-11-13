using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Store;
using Soomla.Levelup;

public class AnimineStoreAssets : IStoreAssets
{
	//asset store prices/values
	public static readonly int[] TOOLS_PRICE = {0,0,200,500,0};//driller, fan, battery, dynamite, bag
	public static readonly int[] HEROS_PRICE = {0,20000,50000,80000,150000};//piggy, cowy, bearry, tigey, draggy
	public static readonly int[] UPGRADE_PRICE = {8000,15000,25000,35000,45000};
	public static readonly double[] INAPP_PRICE = {0.99,1.99,2.99};
	public static readonly int[] INAPP_COIN_AMOUNT = {5000,15000,30000}; 


	public int GetVersion ()
	{
		return 0;
	}

	public VirtualCurrency[] GetCurrencies ()
	{
		return new VirtualCurrency[]{GOLD_COIN_VC};
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
			DRAGGY_VG,
			DRILLER_VG_U1,
			DRILLER_VG_U2,
			DRILLER_VG_U3,
			DRILLER_VG_U4,
			DRILLER_VG_U5,
			FAN_VG_U1,
			FAN_VG_U2,
			FAN_VG_U3,
			FAN_VG_U4,
			FAN_VG_U5,
			BATTERY_VG_U1,
			BATTERY_VG_U2,
			BATTERY_VG_U3,
			BATTERY_VG_U4,
			BATTERY_VG_U5,
			BAG_VG_U1,
			BAG_VG_U2,
			BAG_VG_U3,
			BAG_VG_U4,
			BAG_VG_U5
		};
	}

	public VirtualCurrencyPack[] GetCurrencyPacks ()
	{
		return new VirtualCurrencyPack[] {
			STACK_OF_COINS_VCP,
			BAG_OF_COINS_VCP,
			VAULT_OF_COINS_VCP
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
	public const string DRILLER_VG_U1_ITEM_ID = "driller_vg_u1";
	public const string DRILLER_VG_U2_ITEM_ID = "driller_vg_u2";	
	public const string DRILLER_VG_U3_ITEM_ID = "driller_vg_u3";	
	public const string DRILLER_VG_U4_ITEM_ID = "driller_vg_u4";
	public const string DRILLER_VG_U5_ITEM_ID = "driller_vg_u5";
	public const string FAN_VG_U1_ITEM_ID = "fan_vg_u1";
	public const string FAN_VG_U2_ITEM_ID = "fan_vg_u2";
	public const string FAN_VG_U3_ITEM_ID = "fan_vg_u3";
	public const string FAN_VG_U4_ITEM_ID = "fan_vg_u4";
	public const string FAN_VG_U5_ITEM_ID = "fan_vg_u5";
	public const string BATTERY_VG_U1_ITEM_ID = "battery_vg_u1";
	public const string BATTERY_VG_U2_ITEM_ID = "battery_vg_u2";
	public const string BATTERY_VG_U3_ITEM_ID = "battery_vg_u3";
	public const string BATTERY_VG_U4_ITEM_ID = "battery_vg_u4";
	public const string BATTERY_VG_U5_ITEM_ID = "battery_vg_u5";
	public const string BAG_VG_U1_ITEM_ID = "bag_vg_u1";
	public const string BAG_VG_U2_ITEM_ID = "bag_vg_u2";
	public const string BAG_VG_U3_ITEM_ID = "bag_vg_u3";
	public const string BAG_VG_U4_ITEM_ID = "bag_vg_u4";
	public const string BAG_VG_U5_ITEM_ID = "bag_vg_u5";


	public static VirtualCurrency GOLD_COIN_VC = new VirtualCurrency (
		"GoldCoin",
		"Coin Currency",
		GOLD_COIN_VC_ITEM_ID 
	);

	//virtual currency pack	
	public static VirtualCurrencyPack STACK_OF_COINS_VCP = new VirtualCurrencyPack (
		"stack of coins",
		"",
		"stack_of_coins_vcp",
		INAPP_COIN_AMOUNT[0],
		GOLD_COIN_VC_ITEM_ID,
		new PurchaseWithMarket (
		"com.tetraalpha.stack_of_coins",
		INAPP_PRICE[0])
	);
	public static VirtualCurrencyPack BAG_OF_COINS_VCP = new VirtualCurrencyPack (
		"bag of coins",
		"",
		"bag_of_fish_vcp",
		INAPP_COIN_AMOUNT[1],
		GOLD_COIN_VC_ITEM_ID,
		new PurchaseWithMarket (
		"com.tetralpha.bag_of_coins",
		INAPP_PRICE[1])
	);
	public static VirtualCurrencyPack VAULT_OF_COINS_VCP = new VirtualCurrencyPack (
		"vault of coins",
		"",
		"vault_of_coins_vcp",
		INAPP_COIN_AMOUNT[2],
		GOLD_COIN_VC_ITEM_ID,
		new PurchaseWithMarket (
		"com.shnappy.vault_of_coins",
		INAPP_PRICE[2])
	);
	
	//virtual goods
	public static VirtualGood DRILLER_VG = new SingleUseVG (
		"driller",
		"",
		DRILLER_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		TOOLS_PRICE[0])
	);
	public static VirtualGood FAN_VG = new SingleUseVG (
		"fan",
		"",
		FAN_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		TOOLS_PRICE[1])
		);
	public static VirtualGood BATTERY_VG = new SingleUseVG (
		"battery",
		"",
		BATTERY_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		TOOLS_PRICE[2])
		);
	public static VirtualGood DYNAMITE_VG = new SingleUseVG (
		"dynamite",
		"",
		DYNAMITE_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		TOOLS_PRICE[3])
		);
	public static VirtualGood BAG_VG = new SingleUseVG (
		"bag",
		"",
		BAG_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		TOOLS_PRICE[4])
		);

	//upgrades
	public static VirtualGood DRILLER_VG_U1 = new UpgradeVG (
		DRILLER_VG_ITEM_ID,
		DRILLER_VG_U2_ITEM_ID,
		null,
		DRILLER_VG_U1_ITEM_ID,
		"",
		DRILLER_VG_U1_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[0])
		);
	
	public static VirtualGood DRILLER_VG_U2 = new UpgradeVG (
		DRILLER_VG_ITEM_ID,
		DRILLER_VG_U3_ITEM_ID,
		DRILLER_VG_U1_ITEM_ID,
		DRILLER_VG_U2_ITEM_ID,
		"",
		DRILLER_VG_U2_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[1])
		);
	public static VirtualGood DRILLER_VG_U3 = new UpgradeVG (
		DRILLER_VG_ITEM_ID,
		DRILLER_VG_U4_ITEM_ID,
		DRILLER_VG_U2_ITEM_ID,
		DRILLER_VG_U3_ITEM_ID,
		"",
		DRILLER_VG_U3_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[2])
		);
	public static VirtualGood DRILLER_VG_U4 = new UpgradeVG (
		DRILLER_VG_ITEM_ID,
		DRILLER_VG_U5_ITEM_ID,
		DRILLER_VG_U3_ITEM_ID,
		DRILLER_VG_U4_ITEM_ID,
		"",
		DRILLER_VG_U4_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[3])
		);
	public static VirtualGood DRILLER_VG_U5 = new UpgradeVG (
		DRILLER_VG_ITEM_ID,
		null,
		DRILLER_VG_U4_ITEM_ID,
		DRILLER_VG_U5_ITEM_ID,
		"",
		DRILLER_VG_U5_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[4])
		);

	public static VirtualGood FAN_VG_U1 = new UpgradeVG (
		FAN_VG_ITEM_ID,
		FAN_VG_U2_ITEM_ID,
		null,
		FAN_VG_U1_ITEM_ID,
		"",
		FAN_VG_U1_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[0])
		);
	public static VirtualGood FAN_VG_U2 = new UpgradeVG (
		FAN_VG_ITEM_ID,
		FAN_VG_U3_ITEM_ID,
		FAN_VG_U1_ITEM_ID,
		FAN_VG_U2_ITEM_ID,
		"",
		FAN_VG_U2_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[1])
		);
	public static VirtualGood FAN_VG_U3 = new UpgradeVG (
		FAN_VG_ITEM_ID,
		FAN_VG_U4_ITEM_ID,
		FAN_VG_U2_ITEM_ID,
		FAN_VG_U3_ITEM_ID,
		"",
		FAN_VG_U3_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[2])
		);
	public static VirtualGood FAN_VG_U4 = new UpgradeVG (
		FAN_VG_ITEM_ID,
		FAN_VG_U5_ITEM_ID,
		FAN_VG_U3_ITEM_ID,
		FAN_VG_U4_ITEM_ID,
		"",
		FAN_VG_U4_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[3])
		);
	public static VirtualGood FAN_VG_U5 = new UpgradeVG (
		FAN_VG_ITEM_ID,
		null,
		FAN_VG_U4_ITEM_ID,
		FAN_VG_U5_ITEM_ID,
		"",
		FAN_VG_U5_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[4])
		);
	public static VirtualGood BATTERY_VG_U1 = new UpgradeVG (
		BATTERY_VG_ITEM_ID,
		BATTERY_VG_U2_ITEM_ID,
		null,
		BATTERY_VG_U1_ITEM_ID,
		"",
		BATTERY_VG_U1_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[0])
		);
	public static VirtualGood BATTERY_VG_U2 = new UpgradeVG (
		BATTERY_VG_ITEM_ID,
		BATTERY_VG_U3_ITEM_ID,
		BATTERY_VG_U1_ITEM_ID,
		BATTERY_VG_U2_ITEM_ID,
		"",
		BATTERY_VG_U2_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[1])
		);
	public static VirtualGood BATTERY_VG_U3 = new UpgradeVG (
		BATTERY_VG_ITEM_ID,
		BATTERY_VG_U4_ITEM_ID,
		BATTERY_VG_U2_ITEM_ID,
		BATTERY_VG_U3_ITEM_ID,
		"",
		BATTERY_VG_U3_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[2])
		);
	public static VirtualGood BATTERY_VG_U4 = new UpgradeVG (
		BATTERY_VG_ITEM_ID,
		BATTERY_VG_U5_ITEM_ID,
		BATTERY_VG_U3_ITEM_ID,
		BATTERY_VG_U4_ITEM_ID,
		"",
		BATTERY_VG_U4_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[3])
		);
	public static VirtualGood BATTERY_VG_U5 = new UpgradeVG (
		BATTERY_VG_ITEM_ID,
		null,
		BATTERY_VG_U4_ITEM_ID,
		BATTERY_VG_U5_ITEM_ID,
		"",
		BATTERY_VG_U5_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[4])
		);
	public static VirtualGood BAG_VG_U1 = new UpgradeVG (
		BAG_VG_ITEM_ID,
		BAG_VG_U2_ITEM_ID,
		null,
		BAG_VG_U1_ITEM_ID,
		"",
		BAG_VG_U1_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[0])
		);
	public static VirtualGood BAG_VG_U2 = new UpgradeVG (
		BAG_VG_ITEM_ID,
		BAG_VG_U3_ITEM_ID,
		BAG_VG_U1_ITEM_ID,
		BAG_VG_U2_ITEM_ID,
		"",
		BAG_VG_U2_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[1])
		);
	public static VirtualGood BAG_VG_U3 = new UpgradeVG (
		BAG_VG_ITEM_ID,
		BAG_VG_U4_ITEM_ID,
		BAG_VG_U2_ITEM_ID,
		BAG_VG_U3_ITEM_ID,
		"",
		BAG_VG_U3_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[2])
		);
	public static VirtualGood BAG_VG_U4 = new UpgradeVG (
		BAG_VG_ITEM_ID,
		BAG_VG_U5_ITEM_ID,
		BAG_VG_U3_ITEM_ID,
		BAG_VG_U4_ITEM_ID,
		"",
		BAG_VG_U4_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[3])
		);
	public static VirtualGood BAG_VG_U5 = new UpgradeVG (
		BAG_VG_ITEM_ID,
		null,
		BAG_VG_U4_ITEM_ID,
		BAG_VG_U5_ITEM_ID,
		"",
		BAG_VG_U5_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		UPGRADE_PRICE[4])
		);



	//heros

	public static VirtualGood PIGGY_VG = new EquippableVG (
		EquippableVG.EquippingModel.GLOBAL,
		"Piggy",
		"",
		PIGGY_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		HEROS_PRICE[0])
	);
	public static VirtualGood COW_VG = new EquippableVG (
		EquippableVG.EquippingModel.GLOBAL,
		"Cow",
		"",
		COW_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		HEROS_PRICE[1])
	);
	public static VirtualGood BEARRY_VG = new EquippableVG (
		EquippableVG.EquippingModel.GLOBAL,
		"Bearry",
		"",
		BEARRY_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		HEROS_PRICE[2])
	);
	public static VirtualGood TIGEY_VG = new EquippableVG (
		EquippableVG.EquippingModel.GLOBAL,
		"Tigey",
		"",
		TIGEY_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		HEROS_PRICE[3])
	);
	public static VirtualGood DRAGGY_VG = new EquippableVG (
		EquippableVG.EquippingModel.GLOBAL,
		"Draggy",
		"",
		DRAGGY_VG_ITEM_ID,
		new PurchaseWithVirtualItem (
		GOLD_COIN_VC_ITEM_ID,
		HEROS_PRICE[4])
	);

	//virtual category
	public static VirtualCategory GENERAL_CATEGORY = new VirtualCategory ("generalCategory", new List<string> (new string[] {
		DYNAMITE_VG_ITEM_ID,DRILLER_VG_ITEM_ID,FAN_VG_ITEM_ID,BATTERY_VG_ITEM_ID,BAG_VG_ITEM_ID,PIGGY_VG_ITEM_ID,COW_VG_ITEM_ID,BEARRY_VG_ITEM_ID,TIGEY_VG_ITEM_ID,
		DRAGGY_VG_ITEM_ID,DRILLER_VG_U1_ITEM_ID,DRILLER_VG_U2_ITEM_ID,DRILLER_VG_U3_ITEM_ID,DRILLER_VG_U4_ITEM_ID,DRILLER_VG_U5_ITEM_ID,
		FAN_VG_U1_ITEM_ID,FAN_VG_U2_ITEM_ID,FAN_VG_U3_ITEM_ID,FAN_VG_U4_ITEM_ID,FAN_VG_U5_ITEM_ID,
		BATTERY_VG_U1_ITEM_ID,BATTERY_VG_U2_ITEM_ID,BATTERY_VG_U3_ITEM_ID,BATTERY_VG_U4_ITEM_ID,BATTERY_VG_U5_ITEM_ID,
		BAG_VG_U1_ITEM_ID,BAG_VG_U2_ITEM_ID,BAG_VG_U3_ITEM_ID,BAG_VG_U4_ITEM_ID,BAG_VG_U5_ITEM_ID}));

	//equipable model

}
