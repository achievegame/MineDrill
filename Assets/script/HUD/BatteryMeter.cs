using UnityEngine;
using System.Collections;
using Soomla.Store;

public class BatteryMeter : Meter {
	private float BATTERY_DURATION = 60f;
	private int batteryIndex;
	// Use this for initialization
	void Start () {

	}

	void OnEnable(){
		int batteryUpgradeIndex = StoreInventory.GetGoodUpgradeLevel (AnimineStoreAssets.BATTERY_VG_ITEM_ID);
		BATTERY_DURATION = Constants.BATTERY_DURATION[batteryUpgradeIndex];
		StartCoroutine (countdown(BATTERY_DURATION*StoreInventory.GetItemBalance(AnimineStoreAssets.BATTERY_VG_ITEM_ID)));
	}

	void OnDisable(){
		StopAllCoroutines ();
	}

	private IEnumerator countdown(float duartion){
		Debug.Log ("battery duration :"+duartion);
		float remainingTime = duartion;
		float elapsedTime = 0;
		float stratTime = Time.time;
		batteryIndex = 1;
		//use battery
		StoreInventory.TakeItem(AnimineStoreAssets.BATTERY_VG_ITEM_ID,1);
		while (remainingTime>=20 ) {
			elapsedTime = Time.time-stratTime;
			remainingTime = duartion - elapsedTime;
			Value = remainingTime/duartion;
			yield return new WaitForSeconds(Time.deltaTime);

			if( Mathf.FloorToInt(elapsedTime/BATTERY_DURATION) == batteryIndex ){
				//Debug.Log("in battery meter : "+ Mathf.FloorToInt(remainingTime/BATTERY_DURATION)+"  elapsed time:"+remainingTime);
				batteryIndex++;
				StoreInventory.TakeItem(AnimineStoreAssets.BATTERY_VG_ITEM_ID,1);
			}

		}
		MAudioManager.current.PlayTimeAlert ();
		while (remainingTime>=0 ) {
			remainingTime = duartion - (Time.time-stratTime);
			Value = remainingTime/duartion;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		//StoreInventory.TakeItem(AnimineStoreAssets.BATTERY_VG_ITEM_ID,1);
		MAudioManager.current.StopTimeAlert ();
		//Debug.Log("time up");
		HUD.current.GameComplete ();
//		if (timeUp != null) {
//			timeUp();
//		}
	}

}
