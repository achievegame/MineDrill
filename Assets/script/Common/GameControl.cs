using System.Collections;
using UnityEngine;
using Soomla.Store;

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



	private int score;
	private int coin;



	public void SetScore(int value){
		score += value;
		HUD.current.SetScore (score.ToString());
	}

	public void SetScoreNCoin(int scoreValue, int coinValue){
		SetScore (scoreValue);
		coin += coinValue;
	}

	public void GameStart(){
		score = 0;
		coin = 0;
		SetScore (0);
	}

	public void GameOver(bool isWin= false){
		//if (isWin) {
			StoreNMission.current.SetGameScoreAndCoin (score,coin);
			mGameCenter.current.ReportScore ();
		//}

		if (OnGameOver != null) {
			OnGameOver();
		}
	}

	public void CharacterChanged(int index){
		//characterIndex = index;
		// it will set avatar for character
		if (OnCharecterChanged != null) {
			OnCharecterChanged(index);		
		}
	}
}
