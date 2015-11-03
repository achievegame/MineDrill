using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Levelup;
using Soomla;
using Soomla.Store;
using UnityEngine.UI;

public class StoreNMission : MonoBehaviour {

	public static StoreNMission current = null;
	void Awake ()
	{		
		if (current == null)
			current = this;
		else if (current != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	public const int GROUP_LIMIT = 4;
	public const string PENDING_WORK_KEY = "pendingWorkKey";
	public World world;

	public Score missionIndex;

	public Score distanceScore;
	public Score coinScore;


	private Score sharkHitScore;
	private Score collectCoinScore;
	private Score catchDashFishScore;
	private Score enterAndExitCaveScore;
	private Score reachDistanceScore;
	private Score catchDolphinScore;
	private Score dodgeFishHookScore;
	private Score bounceScore;
	private Score dodgeWallsScore;
	private Score surviveInCaveScore;
	private Score distanceWhenEnterinCaveScore;

	VirtualItemReward firstLaunchReward;

	public delegate void SharkHitsWallDel();
	public SharkHitsWallDel SharkHitsWall;
	public delegate void CollectCoinsDel(int value);
	public CollectCoinsDel CollectCoins;
	public delegate void ScoresDel (int distance);
	public ScoresDel Scores;
	public delegate void CatchDashFishDel();
	public CatchDashFishDel CatchDashFish;
	public delegate void CatchDolphinDel(bool comeFromLeft);
	public CatchDolphinDel CatchDolphin;
	public delegate void FishBounceDel();
	public FishBounceDel FishBounce;
	public delegate void EnternExitCaveDel(bool enterIncave, int currentDistance);
	public EnternExitCaveDel EnternExitCave;
	public delegate void DodgingWallsDel();
	public DodgingWallsDel DodgingWalls;
	public delegate void DodgingFishingHookDel();
	public DodgingFishingHookDel DodgingFishHook;

	public delegate void MissionCompleteDel(Mission m);
	public static event MissionCompleteDel MissionComplete;

	Mission m1;
	Mission m2;
	Mission m3;
	Mission m4;
	Mission m5;
	Mission m6;
	Mission m7;
	Mission m8;
	public Mission m9;
	Mission m10;
	Mission m11;
	Mission m12;
	//CHECK_IN_FINAL_BUILD change to original values
	double m1record = 500;//shark hits wall
	double m2record = 1000;//collect coin
	double m3record = 5;//dash fish
	double m4record = 2;
	double m5record = 2000;//reach
	double m6record = 1;//dolphin
	double m7record = 50;//fishing hook
	double m8record = 10;//bounce
	double m9record = 50;//dodge walls
	double m10record = 1000;//servive in cave
	double m11record = 2000;//collect 
	double m12record = 4000;//reach

	void Start(){
		//CHECK_IN_FINAL_BUILD
		//PlayerPrefs.DeleteAll ();
		//StoreEvents.OnCurrencyBalanceChanged += onCurrencyBalanceChanged;
		StoreEvents.OnSoomlaStoreInitialized += OnSoomlaStoreInitialized;
		world = new World ("AnimineWorld");


		missionIndex = new Score ("missionIndexScore", "mission Index", true);
		distanceScore = new Score ("distanceScore", "distance travelled", true);
		coinScore = new Score ("coinScore", "gold fish coin", true);

		sharkHitScore = new Score ("sharkHitScore", "sharkHitScore", true);
		collectCoinScore = new Score ("collectCoinScore","collectCoinScore",true);
		catchDashFishScore = new Score ("catchDashFishScore", "catchDashFishScore", true);
		enterAndExitCaveScore = new Score ("enterAndExitCaveScore", "enterAndExitCaveScore", true);
		reachDistanceScore = new Score ("reachDistanceScore", "reachDistanceScore", true);
		catchDolphinScore = new Score ("catchDolphinScore", "catchDolphinScore", true);
		dodgeFishHookScore = new Score ("dodgeFishHookScore", "dodgeFishHookScore", true);
		bounceScore = new Score ("bounceScore", "bounceScore", true);
		dodgeWallsScore = new Score ("dodgeFishingHookOrWallsScore", "dodgeFishingHookOrWallsScore", true);
		surviveInCaveScore = new Score ("surviveInCaveScore", "surviveInCaveScore", true);
		distanceWhenEnterinCaveScore = new Score ("distanceWhenEnterinCaveScore", "distanceWhenEnterinCaveScore", true);



		world.AddScore (missionIndex);
		world.AddScore (distanceScore);
		world.AddScore (coinScore);
		world.AddScore (sharkHitScore);
		world.AddScore (collectCoinScore);
		world.AddScore (catchDashFishScore);
		world.AddScore (enterAndExitCaveScore);
		world.AddScore (reachDistanceScore);
		world.AddScore (catchDolphinScore);
		world.AddScore (dodgeFishHookScore);
		world.AddScore (bounceScore);
		world.AddScore (dodgeWallsScore);
		world.AddScore (surviveInCaveScore);
		world.AddScore (distanceWhenEnterinCaveScore);



		LevelUpEvents.OnMissionCompleted += onMissionCompleted;


		VirtualItemReward reward50Coins = new VirtualItemReward ("rwd1", "50 coins", AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID, 50);
		reward50Coins.Schedule = Schedule.AnyTimeUnLimited ();
		VirtualItemReward reward100Coins = new VirtualItemReward ("rwd2", "100 coins", AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID, 100);
		reward100Coins.Schedule = Schedule.AnyTimeUnLimited ();
		VirtualItemReward reward250Coins = new VirtualItemReward ("rwd3", "250 coins", AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID, 250);
		reward250Coins.Schedule = Schedule.AnyTimeUnLimited ();
		VirtualItemReward reward300Coins = new VirtualItemReward ("rwd4", "300 coins", AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID, 300);
		reward300Coins.Schedule = Schedule.AnyTimeUnLimited ();
		VirtualItemReward reward500Coins = new VirtualItemReward ("rwd5", "500 coins", AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID, 500);
		reward500Coins.Schedule = Schedule.AnyTimeUnLimited ();

		firstLaunchReward = new VirtualItemReward ("firstLaunchReward", "1 Piggy", AnimineStoreAssets.PIGGY_VG_ITEM_ID, 1);
		Schedule mySch = new Schedule (1);

		m1 = new RecordMission ("m1", "Shark hits wall – "+m1record+" times", new List<Reward> (){reward50Coins}, sharkHitScore.ID, m1record);//50
		m1.Schedule = mySch; 
		m2 = new RecordMission ("m2", "Collect "+m2record+" coins – 1 run", new List<Reward> (){reward100Coins}, collectCoinScore.ID, m2record);//1000
		m2.Schedule = mySch;
		m3 = new RecordMission ("m3", "Catch Dash fish – "+m3record+" times", new List<Reward> (){reward100Coins}, catchDashFishScore.ID, m3record);
		m3.Schedule = mySch;
		m4 = new RecordMission ("m4", "Enter and Exit Cave – In One go", new List<Reward> (){reward50Coins}, enterAndExitCaveScore.ID, m4record);
		m4.Schedule = mySch;
		m5 = new RecordMission ("m5", "Reach "+m5record+"m milestone - 1 run", new List<Reward> (){reward100Coins}, reachDistanceScore.ID, m5record);
		m5.Schedule = new Schedule(1);
		m6 = new RecordMission ("m6", "Catch Dolphin", new List<Reward> (){reward50Coins}, catchDolphinScore.ID, m6record);
		m6.Schedule = mySch;
		m7 = new RecordMission ("m7", "Dodge "+m7record+" Fishing hook – near miss", new List<Reward> (){reward100Coins}, dodgeFishHookScore.ID, m7record);
		m7.Schedule = mySch;
		m8 = new RecordMission ("m8", "Bounce "+m8record+" times", new List<Reward> (){reward100Coins}, bounceScore.ID, m8record);
		m8.Schedule = mySch;
		m9 = new RecordMission ("m9", "Dodge "+m9record+" walls – near miss", new List<Reward> (){reward100Coins}, dodgeWallsScore.ID, m9record);
		m9.Schedule = mySch;
		m10 = new RecordMission ("m10", "Survive in Cave – "+m10record+"m", new List<Reward> (){reward500Coins}, surviveInCaveScore.ID, m10record);
		m10.Schedule = mySch;
		m11 = new RecordMission ("m11", "Collect "+m11record+" coins – 1 run", new List<Reward> (){reward250Coins}, collectCoinScore.ID, m11record);//1000
		m11.Schedule = mySch;
		m12 = new RecordMission ("m12", "Reach "+m12record+"m milestone - 1 run", new List<Reward> (){reward300Coins}, reachDistanceScore.ID, m12record);
		m12.Schedule = mySch;

		world.AddMission (m1);
		world.AddMission (m2);
		world.AddMission (m3);
		world.AddMission (m4);
		world.AddMission (m5);
		world.AddMission (m6);
		world.AddMission (m7);
		world.AddMission (m8);
		world.AddMission (m9);
		world.AddMission (m10);
		world.AddMission (m11);
		world.AddMission (m12);

		SoomlaStore.Initialize (new AnimineStoreAssets());
		SoomlaLevelUp.Initialize (world);

	}

	void OnSoomlaStoreInitialized(){
		if (!firstLaunchReward.Owned) {
			firstLaunchReward.Give();
			StoreInventory.EquipVirtualGood (AnimineStoreAssets.PIGGY_VG_ITEM_ID);
			missionIndex.SetTempScore(0);
			missionIndex.Reset(true);
			distanceScore.SetTempScore(0);
			distanceScore.Reset(true);
			coinScore.SetTempScore(0);
			coinScore.Reset(true);

			//CHECK_IN_FINAL_BUILD :delete these 2 line in final build
			StoreInventory.GiveItem(AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID,1500000);
			//StoreInventory.GiveItem(ShnappyStoreAssets.HEART_VC_ITEM_ID,20); 
		}

		compMList = PlayerPrefs.GetString (PENDING_WORK_KEY, "");
		CompletePendingWork ();
		setBlankCall ();
		Invoke ("setAllMissionDelegate", 1f);
	}

	public void SetDistanceAndCoin(int dist, int goldCoin){
		StoreInventory.GiveItem (AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID,goldCoin);
		coinScore.SetTempScore (goldCoin);
		distanceScore.SetTempScore (dist);
		distanceScore.Reset (true);
		coinScore.Reset (true);
		//all other score mission related
		ResetScores ();
	}

	public void ResetScores(){
		CompletePendingWork ();

		if(missionIndex.Record >= GROUP_LIMIT*2 && missionIndex.Record <GROUP_LIMIT*2 && distanceWhenEnterinCaveScore.GetTempScore() != 0 && !m10.IsCompleted()){
			Scores -= mission10;
		}

		world.ResetScores (false);
		Invoke ("setAllMissionDelegate", 1f);

	}

	private void CompletePendingWork(){
		if (compMList == "")
			return;
		string[] compL = compMList.Split (',');
		foreach (string sIndex in compL) {
			int mIndex = int.Parse(sIndex);
			world.Missions[mIndex-1].ForceComplete();
		}
		compMList = "";
		PlayerPrefs.SetString (PENDING_WORK_KEY, compMList);
	}

	//get information when TimeScale = 0
	public bool isMissionCompleted(int missionIndex){
		return world.Missions [missionIndex].IsCompleted() || compMList.Contains ((missionIndex + 1)+"");
	}

	void onMissionCompleted(Mission mission) {
		missionIndex.Inc(missionIndex.Record+1);
		missionIndex.Reset(true);
	}

	//for optimization creating list which will have completed mission index
	private string compMList = "";
	private void onMissionCompleted(int index){
		if (compMList.Contains (index + ""))
			return;
		compMList += (compMList==""? "":",") + index;
		PlayerPrefs.SetString (PENDING_WORK_KEY, compMList);
		if (MissionComplete != null) {
			MissionComplete(world.Missions[index-1]);
		}
	}
	void blankCall(){
	}
	void blankCall1(int value=0){
	}
	void blankCall2 (bool value, int value1){
	}
	void blankCall3(bool value){
	}


	void mission1(){
		sharkHitScore.Inc (1);	
		if (sharkHitScore.HasTempReached (m1record)) {
			onMissionCompleted(1);
			//sharkHitScore.Reset(true);
			SharkHitsWall -= mission1;
		}
	}

	void mission2(int value){
		//Debug.Log ("collect coin mission 2!!!");
		collectCoinScore.SetTempScore (value);	
		if (collectCoinScore.HasTempReached (m2record)) {
			onMissionCompleted(2);
			//collectCoinScore.Reset(true);
			CollectCoins -= mission2;
		}
	}

	void mission3(){
		catchDashFishScore.Inc (1);		
		if (catchDashFishScore.HasTempReached (m3record)) {
			onMissionCompleted(3);
			//catchDashFishScore.Reset(true);
			CatchDashFish -= mission3;
		}
	}

	void mission4(bool isInTopSea, int currentDistance){
		if (!isInTopSea) {
			enterAndExitCaveScore.SetTempScore(1);
		} else {
			if(enterAndExitCaveScore.GetTempScore() == 1){
				enterAndExitCaveScore.Inc(1);
				onMissionCompleted(4);
				//enterAndExitCaveScore.Reset(true);
				EnternExitCave -= mission4;
			}else{
				enterAndExitCaveScore.Reset(false);
			}
		}
	}

	void mission5(int value){
		reachDistanceScore.SetTempScore (value);
		if (reachDistanceScore.HasTempReached (m5record)) {
			onMissionCompleted(5);
			//reachDistanceScore.Reset(true);
			Scores -= mission5;
		}
	}

	void mission6(bool comeFromLeft){
		if (comeFromLeft)
			return;
		catchDolphinScore.Inc (1);	
		if (catchDolphinScore.HasTempReached (m6record)) {
			onMissionCompleted(6);
			//catchDolphinScore.Reset(true);
			CatchDolphin -= mission6;
		}
	}
	void mission7(){
		dodgeFishHookScore.Inc (1);
		StartCoroutine (mission7Wait());
	}
	IEnumerator mission7Wait(){
		yield return new WaitForSeconds (1.5f);
		if (dodgeFishHookScore.HasTempReached (m7record)) {
			onMissionCompleted(7);
			//dodgeFishHookScore.Reset(true);
			DodgingFishHook -= mission7;
		}
	}
	void mission8(){
		bounceScore.Inc (1);		
		if (bounceScore.HasTempReached (m8record)) {
			onMissionCompleted(8);
			//bounceScore.Reset(true);
			FishBounce -= mission8;
		}
	}
	void mission9(){
		dodgeWallsScore.Inc (1);
		StartCoroutine (mission9Wait());
	}
	IEnumerator mission9Wait(){
		yield return new WaitForSeconds (1.5f);
		if (dodgeWallsScore.HasTempReached (m9record)) {
			onMissionCompleted(9);
			//dodgeWallsScore.Reset(true);
			DodgingWalls -= mission9;
		}
	}
	void mission10condition(bool isInTopSea, int currentDistance){
		if (!isInTopSea) {
			distanceWhenEnterinCaveScore.SetTempScore (currentDistance);
			Scores += mission10;
		} else {
			distanceWhenEnterinCaveScore.Reset(false);
			surviveInCaveScore.Reset(false);
		}
	}
	void mission10(int value){
		surviveInCaveScore.SetTempScore (value-distanceWhenEnterinCaveScore.GetTempScore());	
		if (surviveInCaveScore.HasTempReached (m10record)) {
			distanceWhenEnterinCaveScore.Reset(false);
			onMissionCompleted(10);
			//surviveInCaveScore.Reset(true);
			Scores -= mission10;
			EnternExitCave -= mission10condition;
		}
	}
	void mission11(int value){
		//Debug.Log ("collect coin mission 2!!!");
		collectCoinScore.SetTempScore (value);	
		if (collectCoinScore.HasTempReached (m11record)) {
			onMissionCompleted(11);
			//collectCoinScore.Reset(true);
			CollectCoins -= mission11;
		}
	}

	void mission12(int value){
		reachDistanceScore.SetTempScore (value);
		if (reachDistanceScore.HasTempReached (m12record)) {
			onMissionCompleted(12);
			//reachDistanceScore.Reset(true);
			Scores -= mission12;
		}
	}

	void setBlankCall ()
	{
		SharkHitsWall += blankCall;
		CollectCoins += blankCall1;
		Scores += blankCall1;
		CatchDashFish += blankCall;
		CatchDolphin += blankCall3;
		FishBounce += blankCall;
		EnternExitCave += blankCall2;
		DodgingWalls += blankCall;
		DodgingFishHook += blankCall;
	}

	private bool[] sectionCheck = new bool[]{false,false,false};
	void setAllMissionDelegate(){
		int section = (int)missionIndex.Record / GROUP_LIMIT;
		if (sectionCheck [section])
			return;
		sectionCheck [section] = true;
		switch (section) {
		case 0:
//			Debug.Log("m1 "+m1.IsCompleted ());
//			Debug.Log("m2 "+m2.IsCompleted ());
//			Debug.Log("m3 "+m3.IsCompleted ());
//			Debug.Log("m4 "+m4.IsCompleted ());
			if (!m1.IsCompleted ()) {
				SharkHitsWall += mission1;
			}
			if (!m2.IsCompleted ()) {					
				CollectCoins += mission2;
			}
			if (!m3.IsCompleted ()) {
				CatchDashFish += mission3;
			}
			if (!m4.IsCompleted ()) {
				EnternExitCave += mission4;	
			}
			break;
		case 1:
//			Debug.Log("m5 "+m5.IsCompleted ());
//			Debug.Log("m6 "+m6.IsCompleted ());
//			Debug.Log("m7 "+m7.IsCompleted ());
//			Debug.Log("m8 "+m8.IsCompleted ());
			if (!m5.IsCompleted ()) {					
				Scores += mission5;
			}
				
			if (!m6.IsCompleted ()) {
				CatchDolphin += mission6;
			}
			if (!m7.IsCompleted ()) {
				DodgingFishHook += mission7;
			}
			if (!m8.IsCompleted ()) {
				FishBounce += mission8;
			}
			break;
		case 2:
			//Debug.Log("m9 "+m9.IsCompleted ());
		//	Debug.Log("m10 "+m10.IsCompleted ());
//			Debug.Log("m11 "+m11.IsCompleted ());
//			Debug.Log("m12 "+m12.IsCompleted ());
			if (!m9.IsCompleted ()) {
				DodgingWalls += mission9;
			}
			if (!m10.IsCompleted ()) {
				EnternExitCave += mission10condition;
			}
			if (!m11.IsCompleted ()) {				
				CollectCoins += mission11;
			}
			if (!m12.IsCompleted ()) {				
				Scores += mission12;
			}
			break;
		}
	}
}
