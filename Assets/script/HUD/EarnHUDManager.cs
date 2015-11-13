using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Store;
public class EarnHUDManager : PopUp {
	[SerializeField]
	private Text prizeCount;
	void Start(){
		watchingVideo = false;
		SetVideoAd ();
	}
	int goldFishCount;
	public void SetVideoAd(){
		goldFishCount=Random.Range(1,4)*25;
	
		AdManager.current.goldCoinCount = goldFishCount;
		prizeCount.text = LanguageManager.current.getSentance(LanguageNode.GetCoins_Sentance,goldFishCount.ToString());
	}

	private bool watchingVideo=false;
	public void WatchVideo(){
		if (watchingVideo)
			return;
		watchingVideo = true;
		AdManager.current.ShowAd (AdManager.REWARDED_VIDEO);
		StartCoroutine (WatchVideoAfter());
	}

	IEnumerator WatchVideoAfter(){
		yield return new WaitForSeconds (0.5f);
		watchingVideo = false;
		Close ();
	}

}
