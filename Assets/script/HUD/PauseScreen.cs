using UnityEngine;
using System.Collections;

public class PauseScreen : PopUp {

	public void Resume(){
		Time.timeScale = 1;
		Destroy (gameObject);
	}

	public void MainMenu(){
		if (isBusy)
			return;
		Time.timeScale = 1;
		BrickManager.current.SaveGame ();
		HUD.current.MainMenu ();
		GameControl.current.GameOver ();
		Destroy (gameObject);
	}
}
