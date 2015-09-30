using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	// Use this for initialization
	private int id;
	private BrickType brickType = BrickType.A;
	private SpriteRenderer spr;
	private int drilledAmount = 0;
	private string neighbourCode = "1111";//right,top,left,bottom 1-NonDrilled Neighbour, 0-DrilledNeighbour
	private int drilledRate = 5;

	public void init(int id,int drilledAmount, BrickType brickType,string neighbourCode="1111"){
		this.id = id;
		this.drilledAmount = drilledAmount;
		this.brickType = brickType;
		this.neighbourCode = neighbourCode;
		//set sprite using drilledAmount neighbourCode and BrickManager sprites
		spr = GetComponent<SpriteRenderer> ();
		spr.color = new Color ((float)brickType/255,(float)brickType/255,(float)brickType/255);
		if (drilledAmount < 100) {
			int nonDrilledSpriteIndex = drilledAmount/17;
			if(nonDrilledSpriteIndex==0 && id < BrickManager.COLUMN){
				spr.sprite = BrickManager.current.S_Brick_Grass;
			}else{
				spr.sprite = BrickManager.current.NonDrilledBrick[nonDrilledSpriteIndex];
			}
		} else {
			Drilled();
		}
		//calculate drilledrate
		drilledRate=(int)(((int)this.brickType-115)*0.05f);
		//Debug.Log (brickType+" : "+drilledRate);
	}

	public void StratDrilling(RelativeDirection drilledPostion){
		if (drilledAmount < 100) {
			drilledAmount+=drilledRate;//calculated by brick strength && drill machine strength
			int nonDrilledSpriteIndex = drilledAmount/17;
			spr.sprite = BrickManager.current.NonDrilledBrick[Mathf.Min(nonDrilledSpriteIndex,5)];
		} else {
			setNeighCode(drilledPostion);
			Drilled();
			BrickManager.current.NeighbourChanged(id);
		}
	}

	public void Drilled(){
		//remove boxCollider
		//set sprite using neighbourCode and BrickManager sprites
		Destroy(GetComponent<BoxCollider2D>());
		setDrilledSprite ();
	}

	public void NeighbourChanged(RelativeDirection neighD){
		//change neighbourCode using neighD
		//set sprite using neighbourCode and BrickManager sprites
		setNeighCode (neighD);
		if (drilledAmount >= 100) {
			setDrilledSprite();
		}
	}

	private void setNeighCode(RelativeDirection relDir){
		neighbourCode=neighbourCode.Remove((int)relDir,1);
		neighbourCode=neighbourCode.Insert((int)relDir,"0");
	}

	private void setDrilledSprite(){
		Vector2 indexNangle = DrilledSpriteNAngle(neighbourCode);
		spr.sprite = BrickManager.current.DrilledBrick[(int)indexNangle.x];
		transform.rotation = Quaternion.Euler(0,0,indexNangle.y);
	}

	public static Vector2 DrilledSpriteNAngle(string neighbourCode){
		Vector2 indexNAngle = Vector2.zero;
		switch(neighbourCode){
		case "1111":
		case "0000":
			indexNAngle.x=0;
			break;
		
		case "0010":
			indexNAngle.x=1;
			indexNAngle.y=0;
			break;
		case "0001":
			indexNAngle.x=1;
			indexNAngle.y=90;
			break;
		case "1000":
			indexNAngle.x=1;
			indexNAngle.y=180;
			break;
		case "0100":
			indexNAngle.x=1;
			indexNAngle.y=270;
			break;

		case "0011":
			indexNAngle.x=2;
			indexNAngle.y=0;
			break;
		case "1001":
			indexNAngle.x=2;
			indexNAngle.y=90;
			break;
		case "1100":
			indexNAngle.x=2;
			indexNAngle.y=180;
			break;
		case "0110":
			indexNAngle.x=2;
			indexNAngle.y=270;
			break;

		case "0101":
			indexNAngle.x=3;
			indexNAngle.y=0;
			break;
		case "1010":
			indexNAngle.x=3;
			indexNAngle.y=90;
			break;

		case "0111":
			indexNAngle.x=4;
			indexNAngle.y=0;
			break;
		case "1011":
			indexNAngle.x=4;
			indexNAngle.y=90;
			break;
		case "1101":
			indexNAngle.x=4;
			indexNAngle.y=180;
			break;
		case "1110":
			indexNAngle.x=4;
			indexNAngle.y=270;
			break;
		}
		return indexNAngle;

	}


}
