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

	public const int GROUP_LIMIT = 2;
	public const string PENDING_WORK_KEY = "pendingWorkKey";
	public World world;

	public Score missionIndex;

	public Score gameScore;
	//public Score coinScore;

	private Score mineralCollectScore;
	private Score brickDigScore;
	private Score stoneBlastScore;
	private Score tigeyAsHeroScore;
	private Score collectCoalScore;
	private Score collectGoldScore;
	private Score collectDiamondScore;
	private Score upgradeBatteryScore;

	VirtualItemReward firstLaunchReward;
	//	public delegate void CollectCoinsDel(int value);
	//	public CollectCoinsDel CollectCoins;
	public delegate void ScoresDel (int distance);
	public ScoresDel Scores;
	public delegate void CollectMineralsDel(MineralType mnrlT);
	public CollectMineralsDel CollectMinerals;
	public delegate void DigBrickDel();
	public DigBrickDel DigBrick;
	public delegate void BlastStoneDel();
	public BlastStoneDel BlastStone;
	public delegate void TigeyAsHeroDel();
	public TigeyAsHeroDel TigeyAsHero;
	public delegate void UpgradeBatteryDel();
	public UpgradeBatteryDel UpgradeBattery;

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
	double m1record = 1000;//score points
	double m2record = 500;//collect minerals
	double m3record = 1000;//dig bricks
	double m4record = 100;// blast 100 stones
	double m5record = 1;//tigey as a hero
	double m6record = 1000;//collect coal
	double m7record = 1000;//collect Golds
	double m8record = 1000;//collect diamonds
	double m9record = 1;//upgrade battery
	double m10record = 10000;//score points

	void Start(){
		//CHECK_IN_FINAL_BUILD
		//PlayerPrefs.DeleteAll ();
		//StoreEvents.OnCurrencyBalanceChanged += onCurrencyBalanceChanged;
		StoreEvents.OnSoomlaStoreInitialized += OnSoomlaStoreInitialized;
		world = new World ("AnimineWorld");


		missionIndex = new Score ("missionIndexScore", "mission Index", true);
		gameScore = new Score ("gameScore", "Game Score", true);
		//coinScore = new Score ("coinScore", "gold coin", true);

		mineralCollectScore = new Score ("mineralCollectScore", "mineralCollectScore", true);
		brickDigScore = new Score ("brickDigScore", "brickDigScore", true);
		stoneBlastScore = new Score ("stoneBlastScore", "stoneBlastScore", true);
		collectCoalScore = new Score ("collectCoalScore", "collectCoalScore", true);
		collectGoldScore = new Score ("collectGoldScore", "collectGoldScore", true);
		collectDiamondScore = new Score ("collectDiamondScore", "collectDiamondScore", true);
		tigeyAsHeroScore = new Score ("tigeyAsHero", "tigeyAsHero", true);

		world.AddScore (missionIndex);
		world.AddScore (gameScore);
		//world.AddScore (coinScore);
		world.AddScore (mineralCollectScore);
		world.AddScore (brickDigScore);
		world.AddScore (stoneBlastScore);
		world.AddScore (collectCoalScore);
		world.AddScore (collectGoldScore);
		world.AddScore (collectDiamondScore);

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

		m1 = new RecordMission ("m1", "Score "+m1record+" points in one go", new List<Reward> (){reward50Coins}, gameScore.ID, m1record);//50
		m1.Schedule = mySch; 
		m2 = new RecordMission ("m2", "Collect "+m2record+" minerals in one go", new List<Reward> (){reward100Coins}, mineralCollectScore.ID, m2record);//1000
		m2.Schedule = mySch;
		m3 = new RecordMission ("m3", "Dig "+m3record+" Bricks in one go", new List<Reward> (){reward100Coins}, brickDigScore.ID, m3record);
		m3.Schedule = mySch;
		m4 = new RecordMission ("m4", "Blast "+m4record+" Stones in One go", new List<Reward> (){reward50Coins}, stoneBlastScore.ID, m4record);
		m4.Schedule = mySch;
		m5 = new RecordMission ("m5", "Use Tigey as a hero", new List<Reward> (){reward100Coins}, null, m5record);
		m5.Schedule = new Schedule(1);
		m6 = new RecordMission ("m6", "Collect "+m6record+" coal in one go", new List<Reward> (){reward50Coins}, collectCoalScore.ID, m6record);
		m6.Schedule = mySch;
		m7 = new RecordMission ("m7", "Collect "+m7record+" Gold in one go", new List<Reward> (){reward100Coins}, collectGoldScore.ID, m7record);
		m7.Schedule = mySch;
		m8 = new RecordMission ("m8", "Collect "+m8record+" Diamond in one go", new List<Reward> (){reward100Coins}, collectDiamondScore.ID, m8record);
		m8.Schedule = mySch;
		m9 = new RecordMission ("m9", "Upgrade Battery to its full power", new List<Reward> (){reward100Coins}, upgradeBatteryScore.ID, m9record);
		m9.Schedule = mySch;
		m10 = new RecordMission ("m10", "Score "+m10record+" points in one go", new List<Reward> (){reward500Coins}, gameScore.ID, m10record);
		m10.Schedule = mySch;

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

		SoomlaStore.Initialize (new AnimineStoreAssets());
		SoomlaLevelUp.Initialize (world);

	}

	void OnSoomlaStoreInitialized(){
		if (!firstLaunchReward.Owned) {
			firstLaunchReward.Give();
			StoreInventory.EquipVirtualGood (AnimineStoreAssets.PIGGY_VG_ITEM_ID);
			missionIndex.SetTempScore(0);
			missionIndex.Reset(true);
			gameScore.SetTempScore(0);
			gameScore.Reset(true);
//			coinScore.SetTempScore(0);
//			coinScore.Reset(true);

			//CHECK_IN_FINAL_BUILD :delete these 2 line in final build
			StoreInventory.GiveItem(AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID,1500000);
			//StoreInventory.GiveItem(ShnappyStoreAssets.HEART_VC_ITEM_ID,20); 
		}

		compMList = PlayerPrefs.GetString (PENDING_WORK_KEY, "");
		CompletePendingWork ();
		setBlankCall ();
		Invoke ("setAllMissionDelegate", 1f);
	}

	public void SetGameScoreAndCoin(int gScore, int goldCoin){
		StoreInventory.GiveItem (AnimineStoreAssets.GOLD_COIN_VC_ITEM_ID,goldCoin);
		//coinScore.SetTempScore (goldCoin);
		gameScore.SetTempScore (gScore);
		gameScore.Reset (true);
		//coinScore.Reset (true);
		//all other score mission related
		ResetScores ();
	}

	public void ResetScores(){
		CompletePendingWork ();

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
	void blankCall2(MineralType mnrl){
	}



	void mission1(int value){
		gameScore.SetTempScore (value);	
		if (gameScore.HasTempReached (m1record)) {
			onMissionCompleted(1);
			Scores -= mission1;
		}
	}

	void mission2(MineralType mnrl){
		mineralCollectScore.Inc (1);
		if (mineralCollectScore.HasTempReached (m2record)) {
			onMissionCompleted(2);
			CollectMinerals -= mission2;
		}
	}

	void mission3(){
		brickDigScore.Inc (1);		
		if (brickDigScore.HasTempReached (m3record)) {
			onMissionCompleted(3);
			DigBrick -= mission3;
		}
	}

	void mission4(){
		stoneBlastScore.Inc (1);		
		if (stoneBlastScore.HasTempReached (m4record)) {
			onMissionCompleted(4);
			BlastStone -= mission4;
		}
	}

	void mission5(){
		onMissionCompleted(5);
		TigeyAsHero -= mission5;
	}

	void mission6(MineralType mnrl){
		if (mnrl != MineralType.Coal)
			return;
		collectCoalScore.Inc (1);
		if (collectCoalScore.HasTempReached (m6record)) {
			onMissionCompleted(6);
			CollectMinerals -= mission6;
		}
	}

	void mission7(MineralType mnrl){
		if (mnrl != MineralType.Gold)
			return;
		collectGoldScore.Inc (1);
		if (collectGoldScore.HasTempReached (m7record)) {
			onMissionCompleted(7);
			CollectMinerals -= mission7;
		}
	}

	void mission8(MineralType mnrl){
		collectDiamondScore.Inc (1);
		if (collectDiamondScore.HasTempReached (m8record)) {
			onMissionCompleted(8);
			CollectMinerals -= mission8;
		}
	}

	void mission9(){
		onMissionCompleted(9);
		UpgradeBattery -= mission5;
	}

	void mission10(int value){
		gameScore.SetTempScore (value);	
		if (gameScore.HasTempReached (m10record)) {
			onMissionCompleted(10);
			Scores -= mission10;
		}
	}


	void setBlankCall ()
	{
		Scores += blankCall1;
		CollectMinerals += blankCall2;
		DigBrick += blankCall;
		BlastStone += blankCall;
		TigeyAsHero += blankCall;
		UpgradeBattery += blankCall;

	}

	private bool[] sectionCheck = new bool[]{false,false,false,false,false};
	void setAllMissionDelegate(){
		int section = (int)missionIndex.Record / GROUP_LIMIT;
		if (sectionCheck [section])
			return;
		sectionCheck [section] = true;
		switch (section) {
		case 0:
			if (!m1.IsCompleted ()) {
				Scores += mission1;
			}
			if (!m2.IsCompleted ()) {					
				CollectMinerals += mission2;
			}
			break;
		case 1:
			if (!m3.IsCompleted ()) {
				DigBrick += mission3;
			}
			if (!m4.IsCompleted ()) {
				BlastStone += mission4;	
			}
			break;
		case 3:
			if (!m5.IsCompleted ()) {					
				TigeyAsHero += mission5;
			}
				
			if (!m6.IsCompleted ()) {
				CollectMinerals += mission6;
			}
			break;
		case 4:
			if (!m7.IsCompleted ()) {
				CollectMinerals += mission7;
			}
			if (!m8.IsCompleted ()) {
				CollectMinerals += mission8;
			}
			break;
		case 5:
			if (!m9.IsCompleted ()) {
				UpgradeBattery += mission9;
			}
			if (!m10.IsCompleted ()) {
				Scores += mission10;
			}		
			break;
		}
	}
}
