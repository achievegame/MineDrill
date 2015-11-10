using UnityEngine;
using System.Collections;
using Soomla.Store;

public class BatteryMeter : Meter {
	const float BATTERY_DURATION = 60f;
	private int batteryIndex;
	// Use this for initialization
	void Start () {

	}

	void OnEnable(){
		StartCoroutine (countdown(BATTERY_DURATION*StoreInventory.GetItemBalance(AnimineStoreAssets.BATTERY_VG_ITEM_ID)));
	}

	void OnDisable(){
		StopAllCoroutines ();
	}

	private IEnumerator countdown(float duartion){
		float remainingTime = duartion;
		float elapsedTime = 0;
		float stratTime = Time.time;
		batteryIndex = 1;
		while (remainingTime>=20 ) {
			elapsedTime = Time.time-stratTime;
			remainingTime = duartion - elapsedTime;
			Value = remainingTime/duartion;
			yield return new WaitForSeconds(Time.deltaTime);

			if( Mathf.FloorToInt(elapsedTime/BATTERY_DURATION) == batteryIndex ){
				Debug.Log("in battery meter : "+ Mathf.FloorToInt(remainingTime/BATTERY_DURATION)+"  elapsed time:"+remainingTime);
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
		StoreInventory.TakeItem(AnimineStoreAssets.BATTERY_VG_ITEM_ID,1);
		MAudioManager.current.StopTimeAlert ();
		Debug.Log("time up");
		HUD.current.GameComplete ();
//		if (timeUp != null) {
//			timeUp();
//		}
	}

}
