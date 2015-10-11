using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	private static readonly int[] DRILLED_RATE = {3,1,-1,-3,-5,-7,-9,-11};
	private static readonly float[] BRICK_COLOR = {1f,0.92f,0.84f,0.76f,0.68f,0.60f,0.52f,0.44f};

	// Use this for initialization
	private int id;
	private BrickType brickType = BrickType.A;
	private SpriteRenderer spr;
	private int drilledAmount = 0;
	private string neighbourCode = "1111";//right,top,left,bottom 1-NonDrilled Neighbour, 0-DrilledNeighbour
	public GameObject mineral;

	public void init(int id,int drilledAmount, BrickType brickType,string neighbourCode="1111"){
		this.id = id;
		this.drilledAmount = drilledAmount;
		this.brickType = brickType;
		this.neighbourCode = neighbourCode;
		//set sprite using drilledAmount neighbourCode and BrickManager sprites
		spr = GetComponent<SpriteRenderer> ();
		spr.color = new Color (BRICK_COLOR[(int)brickType],BRICK_COLOR[(int)brickType],BRICK_COLOR[(int)brickType]);
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
	}

	public void StratDrilling(RelativeDirection drilledPostion){
		if (drilledAmount < 100) {
			drilledAmount+=Mathf.Max(0,DRILLED_RATE[(int)brickType])+2;//calculated by brick strength && drill machine strength
			int nonDrilledSpriteIndex = Mathf.Min(drilledAmount,100)/17;//may be 17,18,19
			spr.sprite = BrickManager.current.NonDrilledBrick[nonDrilledSpriteIndex];
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
		//if has minarls then drop it
		if (mineral) {
			Rigidbody2D r2d = (Rigidbody2D)mineral.GetComponent<Rigidbody2D> ();
			r2d.isKinematic = false;
		}
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
