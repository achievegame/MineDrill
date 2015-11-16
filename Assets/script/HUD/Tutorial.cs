using UnityEngine;
using System.Collections;

public class Tutorial : PopUp {

	public void MainMenu(){
		if (isBusy)
			return;
		HUD.current.MainMenu ();
		Destroy (gameObject);
	}
}
