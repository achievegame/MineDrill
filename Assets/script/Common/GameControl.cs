using System.Collections;
using UnityEngine;

public class GameControl : MonoBehaviour 
{
	public static GameControl current;	//a reference to our game control so we can access it statically
	public HUD hud;

	#region event
	public static event characterChanged OnCharecterChanged;
	public static event gameOverAction OnGameOver;
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

	public void CharacterChanged(int index){
		//characterIndex = index;
		// it will set avatar for character
		if (OnCharecterChanged != null) {
			OnCharecterChanged(index);		
		}
	}

	public void GameOver(){
		if (OnGameOver != null) {
			OnGameOver();
		}
	}
}
