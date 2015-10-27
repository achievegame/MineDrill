using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {

	public void Resume(){
		Time.timeScale = 1;
		Destroy (gameObject);
	}


	public void MainMenu(){
		Time.timeScale = 1;
		HUD.current.LoadAgain ();
	}
}
