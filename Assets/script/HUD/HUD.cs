using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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

	public mPlayerControl player;

	private bool busy = false;

	public void LoadAgain(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void OpenHeroes(){
		LoadHUD (Constants.HUD_HEROES);
	}
	
	public void OpenStore(){
		LoadHUD (Constants.HUD_STORE);
	}

	public void OpenBag(){
		LoadHUD (Constants.HUD_BAG);
	}

	public void OpenSettings(){
		LoadHUD (Constants.HUD_SETTINGS);
	}

	public void OpenLanguages(){
		LoadHUD (Constants.HUD_LANGUAGES);
	}

	public void MainMenu(){
		gamePlay.SetActive (false);
		mainMenu.SetActive (true);
	}

	public void StartNewGame(){
		BrickManager.current.CreateNewMap ();
		StartGame ();
	}
	
	public void StartGame(){
		gamePlay.SetActive (true);
		mainMenu.SetActive (false);
	}

	public void PauseGame(){
		LoadHUD (Constants.HUD_PAUSE_SCREEN);
		Time.timeScale = 0;
	}

	public void DynamiteBlast(){
		player.DynamiteBlast ();
	}


	public GameObject LoadHUD(string hudName){
		GameObject hudPF = Resources.Load<GameObject> (Constants.RESOURCELOCATION_PREFAB+hudName);
		GameObject hudGO = (GameObject)Instantiate (hudPF);
		return hudGO;
	}
	public Text txt;
	public Text txt1;
	public void changeLanguage(){
		Font font = Resources.Load<Font> ("font/Skranji-Bold");
		txt.font = font;
		txt1.font = font;
	}

}
