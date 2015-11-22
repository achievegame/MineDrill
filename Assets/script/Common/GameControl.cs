using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Soomla.Store;

public class GameControl : MonoBehaviour 
{
	public static GameControl current;	//a reference to our game control so we can access it statically
	public HUD hud;

	#region event
	public static event characterChanged OnCharecterChanged;
	public static event gameOverAction OnGameOver;
	public static event mineralAdded OnMineralAdded;
	#endregion event


	void Awake()
	{
		if (current == null) {
			current = this;
		} else if (current != this) {
			Destroy (gameObject);	
		}

		Input.multiTouchEnabled = false;
	}

	private int score;
	public int GameScore{
		get{
			return score;
		}
	}
	private int coin;
	public int TotalCoin{
		get{
			return coin;
		}
	}

	void Start(){
		//set bag
		SetBag ();
	}


	public void SetScore(int value){
		score += value;
		HUD.current.SetScore (score.ToString());
		StoreNMission.current.Scores (score);
	}

	public void SetScoreNCoin(int scoreValue, int coinValue){
		SetScore (scoreValue);
		coin += coinValue;
	}

	public void GameStart(){
		score = 0;
		coin = 0;
		SetScore (0);
		SetHeroSpeed ();
		SetDrillerStrength ();
		SetFanSpeed ();
		MAudioManager.current.PlayGameThemeMusic ();
	}

	public void GameOver(bool isWin= false){
		MAudioManager.current.StopGameThemeMusic ();
		if (isWin) {
			BrickManager.current.SaveGame ();
			StoreNMission.current.SetGameScoreAndCoin (score, coin);
			mGameCenter.current.ReportScore ();
		} else {
			BrickManager.current.RevertMap();
		}

		HUD.current.MainMenu ();

		resetBag ();

		if (OnGameOver != null) {
			OnGameOver();
		}
	}

	public void CharacterChanged(int index){
		characterIndex = index;
		// it will set avatar for character
		if (OnCharecterChanged != null) {
			OnCharecterChanged(index);		
		}
	}

	public int characterIndex{
		get{
			return PlayerPrefs.GetInt(Constants.CHARACTER_KEY,0);
		}
		set{
			PlayerPrefs.SetInt(Constants.CHARACTER_KEY,value);
		}
	}

	public bool AddMineral(MineralType mineralType){
		bool added = false;
		//try to add in  bag
		BagElement bgE;
		for (int i=4; i<16; i++) {
			bgE = bagL[i];
			if(bgE.isLocked)
				break;

			if(bgE.count == 0 || (bgE.elementTypeIndex == (int)mineralType && bgE.count < 10) ){
				bgE.count++;
				bgE.elementTypeIndex = (int)mineralType;
				added = true;
				break;
			}
		}

		if (added) {
			totalMineral++;
			SetScoreNCoin(Constants.MINERAL_PRICE[(int)mineralType],Constants.MINERAL_PRICE[(int)mineralType]);

			if(OnMineralAdded != null){
				OnMineralAdded();
			}
		}


		return added;
	}



	#region Bag

	public List<BagElement> bagL = new List<BagElement> ();
	private int totalMineral = 0;
	private int bagCapacity;
	public float BagMeterValue{
		get{
			return (float)totalMineral/bagCapacity;
		}
	}
	public void refreashBag(bool checkBagUpgrade=false){
		bagL [(int)ToolType.Battery].count = StoreInventory.GetItemBalance (AnimineStoreAssets.BATTERY_VG_ITEM_ID);
		bagL [(int)ToolType.Dynamite].count = StoreInventory.GetItemBalance (AnimineStoreAssets.DYNAMITE_VG_ITEM_ID);
		if (checkBagUpgrade) {
			int bagUpgradeLevel = StoreInventory.GetGoodUpgradeLevel(AnimineStoreAssets.BAG_VG_ITEM_ID);
			bagCapacity = (bagUpgradeLevel*2+2)*10;
			BagElement bgE;
			for (int i = 4; i < bagUpgradeLevel*2+6; i++) {
				bgE = bagL[i];
				bgE.isLocked = false;
				bgE.count=0;
			}
		}

	}
	private void SetBag ()
	{
		BagElement bgE;
		for (int i = 0; i < 4; i++) {
			bgE = new BagElement ();
			bgE.isLocked = false;
			bgE.bagEType = BagElementType.Tools;
			bgE.elementTypeIndex = i;
			bgE.count = 1;
			bagL.Add (bgE);
		}
		
		int bagUpgradeLevel = StoreInventory.GetGoodUpgradeLevel(AnimineStoreAssets.BAG_VG_ITEM_ID);
		bagCapacity = (bagUpgradeLevel*2+2)*10;
		for (int i = 4; i < bagUpgradeLevel*2+6; i++) {
			bgE = new BagElement ();
			bgE.isLocked = false;
			bagL.Add (bgE);
		}

		for (int i = bagUpgradeLevel*2+6; i < 16 ; i++) {
			bgE = new BagElement ();
			bgE.isLocked = true;
			bagL.Add (bgE);
		}
		
		refreashBag ();
	}

	private void resetBag(){
		refreashBag (true);
	}

	#endregion

	#region Driller
	private int[] DRILLER_RATE =  {5,2,1,0,0,0,0,0};
	public int drillerStrenght(BrickType bkType){
		return DRILLER_RATE[(int)bkType];
	}
	private void SetDrillerStrength(){
		int drillerUpgradeLevel = StoreInventory.GetGoodUpgradeLevel (AnimineStoreAssets.DRILLER_VG_ITEM_ID);	
		for (int i=0; i<8; i++) {
			int strength = Mathf.Min (7 + drillerUpgradeLevel, (int)(Constants.INTIAL_DRILLER_STRENGTH [i] + (drillerUpgradeLevel * (drillerUpgradeLevel + 1)) * 0.5f));				
			DRILLER_RATE [i] = Mathf.Max(0,strength);
		}
	}
	#endregion
	#region Hero Speed 
	private float _heroSpeed = 8;
	public float heroSpeed{
		get{
			return _heroSpeed;
		}
	}
	private void SetHeroSpeed(){
		_heroSpeed = Constants.HEROES_SPEED[characterIndex];
	}
	#endregion

	#region Fan
	private int _fanSpeed = 8;
	public int fanSpeed{
		get{
			return _fanSpeed;
		}
	}
	private void SetFanSpeed(){
		int fanUpgradeLevel = StoreInventory.GetGoodUpgradeLevel (AnimineStoreAssets.FAN_VG_ITEM_ID);
		_fanSpeed = Constants.FAN_SPEED[fanUpgradeLevel];
	}
	#endregion
}
