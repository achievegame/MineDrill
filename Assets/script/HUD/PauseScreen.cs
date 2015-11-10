using UnityEngine;
using System.Collections;

public class PauseScreen : PopUp {

	public void Resume(){
		Time.timeScale = 1;
		Destroy (gameObject);
	}

	public void WantToQuit(){
		LoadHUD (Constants.HUD_WANT_TO_QUIT);
		Destroy (gameObject);
	}

}
