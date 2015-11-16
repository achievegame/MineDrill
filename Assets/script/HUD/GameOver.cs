using UnityEngine;
using System.Collections;

public class GameOver : PopUp {

	void OnEnable(){
		MAudioManager.current.StopTimeAlert ();
		Time.timeScale = 0;
	}

	public void MainMenu(){
		if (isBusy)
			return;
		Time.timeScale = 1;
		GameControl.current.GameOver (false);
		Destroy (gameObject);
	}
}
