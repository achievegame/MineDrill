using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using Soomla.Store;

public class AdManager : MonoBehaviour 
{
	public static string VIDEO = "video";
	public static string REWARDED_VIDEO = "rewardedVideo";

	//public static event AdCallbackDelegate AdCallback; 

//	#if UNITY_IOS
//	string gameIDIOS = "64460";//"51596";
//	#else
//	string gameIDAndroid = "64467";//"55958";
//	#endif

	public static AdManager current = null;

	//public bool isGoldCoin = true;
	public int goldCoinCount;	
	public int heartCount;
	
	void Awake ()
	{
		
		if (current == null)
			current = this;
		else if (current != this)
			Destroy (gameObject);			
		
		DontDestroyOnLoad (gameObject);
	}
	
	public void ShowAd(string zone = "")
	{
		Debug.Log ("show Ad");
		if (zone.Equals (REWARDED_VIDEO)) {
			if (Advertisement.IsReady(zone))
			{
				var options = new ShowOptions { resultCallback = HandleShowResult };
				Advertisement.Show(zone, options);
			}
		} else {
			if (Advertisement.IsReady())
			{
				Advertisement.Show();
			}
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			//MAudioManager.current.PlayFx(AudioName.PurchaseClick);
			StoreInventory.GiveItem(AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID,goldCoinCount);
		
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
}