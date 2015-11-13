using UnityEngine;
using System.Collections;

public class QuitScreen : PopUp {

	public void MainMenu(){
		if (isBusy)
			return;
		Time.timeScale = 1;
		GameControl.current.GameOver (false);
		Destroy (gameObject);
	}

	public void Back(){
		LoadHUD (Constants.HUD_PAUSE_SCREEN);
		Destroy (gameObject);
	}
}
