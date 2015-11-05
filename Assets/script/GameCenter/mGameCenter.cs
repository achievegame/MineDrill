using UnityEngine;
using System.Collections;
#if UNITY_ANDROID
using GooglePlayGames;
#endif
using UnityEngine.SocialPlatforms;
using Soomla.Levelup;

public class mGameCenter : MonoBehaviour {
	public static mGameCenter current;
#if UNITY_ANDROID
	readonly string COIN_LEADERBOARD_ID = "CgkIwLa_4twOEAIQAQ";
#else 
	readonly string SCORE_LEADERBOARD_ID = "com.shnappy.distancetraveled";
	readonly string COIN_LEADERBOARD_ID = "com.shnappy.goldfishcoin";
#endif
	void Awake(){
		current = this;
	}
#if UNITY_ANDROID
	void Start () {
		// Select the Google Play Games platform as our social platform implementation
		GooglePlayGames.PlayGamesPlatform.Activate();

	}
#endif

	public void Login(){
		Social.localUser.Authenticate ((bool success) => {

		});
	}

//	public void ShowLeaderboard(){
//		if (Social.localUser.authenticated) {
//			Social.ShowLeaderboardUI ();
//		} else {
//			Social.localUser.Authenticate ((bool success) => {
//				if(success){
//					Social.ShowLeaderboardUI ();
//				}
//
//			});
//		}
//	}

	public void ShowLeaderboard(){
		if (Social.localUser.authenticated) {
			Social.ShowLeaderboardUI ();
		} else {
			Social.localUser.Authenticate ((bool success) => {
				if(success){
					double score = StoreNMission.current.gameScore.Record;
					Social.ReportScore ((long)score, COIN_LEADERBOARD_ID, (bool success1) => {});
					Social.ShowLeaderboardUI ();
				}					
			});
		}
	}

	public void ReportScore(){
		if (Social.localUser.authenticated) {
			double score = StoreNMission.current.gameScore.Record;
			Social.ReportScore ((long)score, COIN_LEADERBOARD_ID, (bool success) => {});
		} 
	}

//	public void ReportScoreDistance(){
//		if (Social.localUser.authenticated) {
//			int distance = StoreNMission.current.distanceScore.Record;
//			Social.ReportScore (distance, SCORE_LEADERBOARD_ID, (bool success) => {});
//		} 
//	}
//
//	public void ReportScoreCoin(){
//		if (Social.localUser.authenticated) {
//			int coin = StoreNMission.current.coinScore.Record;
//			Social.ReportScore (coin, COIN_LEADERBOARD_ID, (bool success) => {});
//		} 
//	}

}
