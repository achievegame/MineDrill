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


	public void LoadAgain(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void OpenHeroes(){
		LoadHUD (Constants.HUD_HEROES);
	}
	
	public void OpenStore(){
		LoadHUD (Constants.HUD_STORE);
	}
	
	public void StartGame(){
		gamePlay.SetActive (true);
		mainMenu.SetActive (false);
	}

	public void PauseGame(){
		LoadHUD (Constants.HUD_PAUSE_SCREEN);
		Time.timeScale = 0;
	}


	public GameObject LoadHUD(string hudName){
		GameObject hudPF = Resources.Load<GameObject> (Constants.RESOURCELOCATION_PREFAB+hudName);
		GameObject hudGO = (GameObject)Instantiate (hudPF);
		return hudGO;
	}

}
