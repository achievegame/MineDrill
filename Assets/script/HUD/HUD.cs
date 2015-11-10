using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Soomla.Store;
public class HUD : MonoBehaviour {
	public static HUD current;	
	void Awake(){
		if (current == null) {
			current = this;
		} else if (current != this) {
			Destroy (gameObject);	
		}
	}
	[SerializeField]
	private GameObject mainMenu;
	[SerializeField]
	private GameObject gamePlay;
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text dynamiteCount;

	public mPlayerControl player;

	private bool busy = false;
	private void setBusyFalse(){
		busy = false;
	}

	private bool isBusy{
		get{
			if (busy) {
				return true;
			}
			
			busy = true;
			Invoke ("setBusyFalse",0.5f);
			return false;
		}
	}

	public void LoadAgain(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void OpenHeroes(){
		if (isBusy)return;
		LoadHUD (Constants.HUD_HEROES);
	}
	
	public void OpenStore(){
		if (isBusy)return;
		LoadHUD (Constants.HUD_STORE);
	}

	public void OpenMission(){
		if (isBusy)return;
		LoadHUD (Constants.HUD_MISSION);
	}

	public void OpenEarnCoin(){
		if (isBusy)return;
		LoadHUD (Constants.HUD_EARN_COIN);
	}

	public void OpenBag(){
		if (isBusy)return;
		LoadHUD (Constants.HUD_BAG);
	}

	public void OpenSettings(){
		if (isBusy)return;
		LoadHUD (Constants.HUD_SETTINGS);
	}

	public void OpenLanguages(){
		if (isBusy)return;
		LoadHUD (Constants.HUD_LANGUAGES);
	}

	public void MainMenu(){
		if (isBusy)return;
		gamePlay.SetActive (false);
		mainMenu.SetActive (true);
	}

	public void StartNewGame(){
		if (isBusy)return;
		BrickManager.current.CreateNewMap ();
		StartGame ();
	}
	
	public void StartGame(){
		if (isBusy)return;
		GameControl.current.GameStart ();
		gamePlay.SetActive (true);
		mainMenu.SetActive (false);
		dynamiteCount.text = StoreInventory.GetItemBalance (AnimineStoreAssets.DYNAMITE_VG_ITEM_ID)+"";
	}

	public void PauseGame(){
		LoadHUD (Constants.HUD_PAUSE_SCREEN);
		Time.timeScale = 0;
	}

	public void GameComplete(){
		if (player.isOnTop ()) {
			LoadHUD (Constants.HUD_GAME_COMPLETE);
		} else {
			LoadHUD(Constants.HUD_GAME_OVER);
		}
	}

	public void DynamiteBlast(){
		if (isBusy)return;
		if (StoreInventory.GetItemBalance (AnimineStoreAssets.DYNAMITE_VG_ITEM_ID) > 0) {
			if(player.DynamiteBlast ()){
				StoreInventory.TakeItem(AnimineStoreAssets.DYNAMITE_VG_ITEM_ID,1);
				dynamiteCount.text = StoreInventory.GetItemBalance (AnimineStoreAssets.DYNAMITE_VG_ITEM_ID)+"";
			}
		}
	}

	public void ShowLeaderboard(){
		#if UNITY_ANDROID
		if (isBusy)return;
		mGameCenter.current.ShowLeaderboard ();
		#endif
	}

	public void SetScore(string value){
		scoreText.text = LanguageManager.current.getText (LanguageNode.Scores) + " : " + value;
	}

	public GameObject LoadHUD(string hudName){
		GameObject hudPF = Resources.Load<GameObject> (Constants.RESOURCELOCATION_PREFAB+hudName);
		GameObject hudGO = (GameObject)Instantiate (hudPF);
		return hudGO;
	}
}
