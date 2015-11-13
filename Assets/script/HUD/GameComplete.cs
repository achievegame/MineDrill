using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameComplete : PopUp {
	[SerializeField]
	private Text stats;

	void Start(){
		string statMsg = LanguageManager.current.getText(LanguageNode.Scores)+" :"+GameControl.current.GameScore+"\n";
		statMsg+= "---------------------------\n";
		statMsg+= LanguageManager.current.getText(LanguageNode.Coins)+"\n";
		BagElement bgE;
		for(int i=4;i<16;i++){
			bgE=GameControl.current.bagL[i];
			if(bgE.count == 0)
				break;

			statMsg += (i-3)+".  "+LanguageManager.current.getText(((MineralType)bgE.elementTypeIndex).ToString())+"    "+bgE.count+"x"+Constants.MINERAL_PRICE[bgE.elementTypeIndex]+"  =  "+bgE.count*Constants.MINERAL_PRICE[bgE.elementTypeIndex]+"\n";
		}
		statMsg+= "---------------------------\n";
		statMsg+= "	     "+LanguageManager.current.getText(LanguageNode.TotalCoins)+" =  "+GameControl.current.TotalCoin;
		stats.text = statMsg;	
	}

	public void MainMenu(){
		if (isBusy)
			return;
		GameControl.current.GameOver (true);
		Destroy (gameObject);
	}
}
