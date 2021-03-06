﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	private static readonly float[] BRICK_COLOR = {1f,0.92f,0.84f,0.76f,0.68f,0.60f,0.52f,0.44f};

	public bool canSave = false;
	// Use this for initialization
	public int id;
	public BrickType brickType = BrickType.A;
	public int drilledAmount = 0;
	public string neighbourCode = "1111";//right,top,left,bottom 1-NonDrilled Neighbour, 0-DrilledNeighbour
	public MineralType mineralType = MineralType.None;

	public GameObject mineral;
	private SpriteRenderer spr;


	public void init(int id,int drilledAmount, BrickType brickType, string neighbourCode="1111", MineralType mineralType = MineralType.None){
		this.id = id;
		this.drilledAmount = drilledAmount;
		this.brickType = brickType;
		this.mineralType = mineralType;
		this.neighbourCode = neighbourCode;
		//set sprite using drilledAmount neighbourCode and BrickManager sprites
		spr = GetComponent<SpriteRenderer> ();
		spr.color = new Color (BRICK_COLOR[(int)brickType],BRICK_COLOR[(int)brickType],BRICK_COLOR[(int)brickType]);
		if (drilledAmount < 100) {
			int nonDrilledSpriteIndex = drilledAmount/17;
			if(nonDrilledSpriteIndex==0 && id < BrickManager.COLUMN){
				if(mineralType == MineralType.NonBreakableStone){
					spr.sprite = BrickManager.current.S_Brick_Stone;
				}else{
					spr.sprite = BrickManager.current.S_Brick_Grass;
				}

			}else{
				spr.sprite = BrickManager.current.NonDrilledBrick[nonDrilledSpriteIndex];
			}
		} else {
			Drilled();
		}
	}

	public bool hasStone(){
		return mineralType == MineralType.Stone;
	}

	public void Blast(RelativeDirection drilledPostion){
		StartCoroutine ("IE_Blast", drilledPostion);
	}

	private IEnumerator IE_Blast(RelativeDirection drilledPostion){
		yield return new WaitForSeconds (1f);
		MAudioManager.current.PlayFx (AudioName.Explosion);
		yield return new WaitForSeconds (0.2f);
		if (mineral && mineralType == MineralType.Stone) {
			Destroy(mineral);
			//brick drilled
			drilledAmount = 100;
			setNeighCode(drilledPostion);
			Drilled();
			BrickManager.current.NeighbourChanged(id);
			StoreNMission.current.BlastStone();
			GameControl.current.SetScore(Constants.STONE_BLAST_SCORE);
		}
	}

	//can be optimize this method
	public void StratDrilling(RelativeDirection drilledPostion){

		if ((int)mineralType >= (int)MineralType.Stone)
			return;
		if (drilledAmount < 100) {
			canSave = true;
			drilledAmount+=GameControl.current.drillerStrenght(brickType);//calculated by brick strength && drill machine strength
			int nonDrilledSpriteIndex = Mathf.Min(drilledAmount,100)/17;//may be 17,18,19
			spr.sprite = BrickManager.current.NonDrilledBrick[nonDrilledSpriteIndex];
		} else {
			setNeighCode(drilledPostion);
			Drilled();
			BrickManager.current.NeighbourChanged(id);
			StoreNMission.current.DigBrick();
			GameControl.current.SetScore(Constants.BRICK_DIGGING_SCORE[(int)brickType]);
		}
	}

	public void Drilled(){
		//remove boxCollider
		//set sprite using neighbourCode and BrickManager sprites
		mineralType = MineralType.None;
		Destroy(GetComponent<BoxCollider2D>());
		setDrilledSprite ();
		if (mineral) {
			Mineral mnrl = mineral.GetComponent<Mineral>();
			mnrl.Active();
		}



		//if has minarls then drop it
//		if (mineral) {
//			Rigidbody2D r2d = (Rigidbody2D)mineral.GetComponent<Rigidbody2D> ();
//			r2d.isKinematic = false;
//		}
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
		canSave = true;
	}

	private void setDrilledSprite(){
		Vector2 indexNangle = DrilledSpriteNAngle(neighbourCode);
		spr.sprite = BrickManager.current.DrilledBrick[(int)indexNangle.x];
		transform.rotation = Quaternion.Euler(0,0,indexNangle.y);
	}

	public static Vector2 DrilledSpriteNAngle(string neighbourCode){
		Vector2 indexNAngle = Vector2.zero;
		switch(neighbourCode){
		case "1111"://15
		case "0000"://0
			indexNAngle.x=0;
			break;
		
		case "0010"://2
			indexNAngle.x=1;
			indexNAngle.y=0;
			break;
		case "0001"://1
			indexNAngle.x=1;
			indexNAngle.y=90;
			break;
		case "1000"://8
			indexNAngle.x=1;
			indexNAngle.y=180;
			break;
		case "0100"://4
			indexNAngle.x=1;
			indexNAngle.y=270;
			break;

		case "0011"://3
			indexNAngle.x=2;
			indexNAngle.y=0;
			break;
		case "1001"://9
			indexNAngle.x=2;
			indexNAngle.y=90;
			break;
		case "1100"://12
			indexNAngle.x=2;
			indexNAngle.y=180;
			break;
		case "0110"://6
			indexNAngle.x=2;
			indexNAngle.y=270;
			break;

		case "0101"://5
			indexNAngle.x=3;
			indexNAngle.y=0;
			break;
		case "1010"://10
			indexNAngle.x=3;
			indexNAngle.y=90;
			break;

		case "0111"://7
			indexNAngle.x=4;
			indexNAngle.y=0;
			break;
		case "1011"://11
			indexNAngle.x=4;
			indexNAngle.y=90;
			break;
		case "1101"://13
			indexNAngle.x=4;
			indexNAngle.y=180;
			break;
		case "1110"://14
			indexNAngle.x=4;
			indexNAngle.y=270;
			break;
		}
		return indexNAngle;

	}


}
