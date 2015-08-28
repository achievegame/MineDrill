using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrickManager : MonoBehaviour {
	public static BrickManager current;

	public const float GRID_WIDTH = 2f;
	public const float GRID_HEIGHT = 2f;
	public const float ONE_BY_GRID_WIDTH = 1 / GRID_WIDTH;
	public const int ROW = 50;
	public const int COLUMN = 50;

	[SerializeField]
	private GameObject BrickFB;

	public Sprite S_Brick_Grass;
	public Sprite[] NonDrilledBrick;
	public Sprite[] DrilledBrick;


	public Sprite S_Brick;
	public Sprite S_Brick_DT_1;
	public Sprite S_Brick_DT_2;
	public Sprite S_Brick_DT_3;
	public Sprite S_Brick_DT_4;
	public Sprite S_Brick_D_0;
	public Sprite S_Brick_D_1;
	public Sprite S_Brick_D_2;
	public Sprite S_Brick_D_2a;
	public Sprite S_Brick_D_3;
	public Sprite S_Brick_Back;

	private List<Brick> bricksList = new List<Brick>();

	void Awake(){
		if (current == null) {
			current = this;
		} else {
			Destroy(this.gameObject);
		}
	}


	// Use this for initialization
	void Start () {
		GameObject brickGO;
		Brick brick;
		for (int i=0; i<ROW; i++) {
			for(int j=0; j<COLUMN; j++){
				brickGO = (GameObject)Instantiate(BrickFB);
				brick = brickGO.GetComponent<Brick>();
				brick.init(i*COLUMN+j,0,i*COLUMN+j<COLUMN ? "1011":"1111");
				brickGO.transform.SetParent(this.transform);
				brickGO.layer = gameObject.layer;
				brickGO.transform.localPosition = new Vector2((j-COLUMN/2)*GRID_WIDTH,-i*GRID_HEIGHT);
				bricksList.Add(brick);
			}
		}	
	}


	public void Drilling(int row, int column, RelativeDirection drilledPosition){
		//Debug.Log ("[BrickManager]: row:"+row+" column:"+column);
		int brickid = row * COLUMN + column + COLUMN / 2;
		if (brickid < 0)
			return;
		//Debug.Log ("brickid:"+brickid);
		bricksList [brickid].StratDrilling (drilledPosition);
	}

	public void StopDrilling(GameObject brick){

	}

	public void NeighbourChanged(int brickId){
		//for right neighbour
		int neighBrickId=0;
		if((brickId+1)%COLUMN!=0){
			neighBrickId = brickId+1;
			bricksList[neighBrickId].NeighbourChanged(RelativeDirection.Left);
		}

		//for top neighbour
		if(brickId-COLUMN >= 0){
			neighBrickId = brickId-COLUMN;
			bricksList[neighBrickId].NeighbourChanged(RelativeDirection.Bottom);
		}

		//for left neighbour
		if(brickId%COLUMN != 0){
			neighBrickId = brickId-1;
			bricksList[neighBrickId].NeighbourChanged(RelativeDirection.Right);
		}

		//for bottom neighbour
		if(brickId+COLUMN < ROW*COLUMN){
			neighBrickId = brickId+COLUMN;
			bricksList[neighBrickId].NeighbourChanged(RelativeDirection.Top);
		}

	}
}
