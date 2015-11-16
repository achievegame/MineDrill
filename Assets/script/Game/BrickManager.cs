using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrickManager : MonoBehaviour {
	public static BrickManager current;

	public const float GRID_WIDTH = 2f;
	public const float GRID_HEIGHT = 2f;
	public const float ONE_BY_GRID_WIDTH = 1 / GRID_WIDTH;
	public const int ROW = 161;
	public const int COLUMN = 50;
	public const int COLUMN_BY_2 = 25;
	public const int BRICK_TYPE_GROUP = 20;

	[SerializeField]
	private GameObject BrickFB;
	[SerializeField]
	private GameObject mineralPF; 

	public Sprite S_Brick_Grass;
	public Sprite S_Brick_Stone;
	public Sprite[] NonDrilledBrick;
	public Sprite[] DrilledBrick;

	public Sprite[] Minerals;

	public PlayerSave playerS;

	private List<Brick> bricksList = new List<Brick>();

	private GameObject container;

	void Awake(){
		if (current == null) {
			current = this;
		} else {
			Destroy(this.gameObject);
		}
	}


	// Use this for initialization
	void Start () {

		playerS = PlayerSave.load ();
		CreateMap ();
			
	}

	void CreateMap(){

		container = new GameObject ("BricksContainer");
		container.transform.localPosition = this.transform.localPosition;
		container.transform.SetParent (this.transform);

		GameObject brickGO;
		GameObject mineralGO;
		Brick brick;
		Mineral mnrl;

		foreach (BrickSave brkSv in playerS.bricks) {
			//Debug.Log(brkSv.id+" "+(BrickType)brkSv.brickType+" "+brkSv.drilledAmount+" "+(MineralType)brkSv.mineralType+" "+brkSv.neighbourCode);
			brickGO = (GameObject)Instantiate(BrickFB);
			brick = brickGO.GetComponent<Brick>();
			brick.init(brkSv.id, brkSv.drilledAmount, (BrickType)brkSv.brickType, brkSv.neighbourCode, brkSv.mineralType);
			brickGO.transform.SetParent(container.transform);
			brickGO.layer = gameObject.layer;
			int i = Mathf.FloorToInt(brkSv.id/COLUMN);
			int j = brkSv.id%COLUMN;
			//Debug.Log("i:"+i+", j:"+j);
			brickGO.transform.localPosition = new Vector2((j-COLUMN/2)*GRID_WIDTH,-i*GRID_HEIGHT);
			if(brkSv.mineralType != MineralType.None && brkSv.mineralType != MineralType.NonBreakableStone){
				mineralGO = (GameObject)Instantiate(mineralPF);
				mineralGO.transform.SetParent(brickGO.transform.parent);
				mineralGO.transform.localPosition = brickGO.transform.localPosition;
				mnrl = mineralGO.GetComponent<Mineral>();
				mnrl.init(brkSv.mineralType);
				brick.mineral = mineralGO;
			}
			
			bricksList.Add(brick);
			
		}
	}

	public void CreateNewMap(){
		bricksList.Clear ();
		Destroy (container);
		playerS = PlayerSave.loadNew ();
		CreateMap ();
	}

	public void RevertMap(){
		bricksList.Clear ();
		Destroy (container);	
		CreateMap ();
	}



	public bool haveStone(int row, int column){
		int brickid = row * COLUMN + column + COLUMN_BY_2;
		if (brickid < 0)
			return false;

		return bricksList [brickid].hasStone ();
	}

	public void Blast(int row, int column){
		int brickid = row * COLUMN + column + COLUMN_BY_2;
		if (brickid < 0)
			return;
		Brick brk = bricksList [brickid];
		//add dynamite blast animation
		GameObject dynamite = Instantiate<GameObject>(Resources.Load<GameObject> (Constants.RESOURCELOCATION_PREFAB + "Blast"));
		dynamite.transform.SetParent (brk.transform.parent);
		dynamite.transform.localPosition = brk.transform.localPosition;
		brk.Blast (RelativeDirection.Top);
	}


	public void Drilling(int row, int column, RelativeDirection drilledPosition){
		//Debug.Log ("[BrickManager]: row:"+row+" column:"+column);
		Debug.Log ("column:" + column);
		int brickid = row * COLUMN + column + COLUMN_BY_2;
		if (brickid < 0 || column == 25 || column == -26)
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

	private BrickType getBrickType(int columnIndex){
		if (columnIndex < BRICK_TYPE_GROUP) {
			return BrickType.A;
		} else if (columnIndex < BRICK_TYPE_GROUP * 2) {
			return BrickType.B;
		} else if (columnIndex < BRICK_TYPE_GROUP * 3) {
			return BrickType.C;
		} else if (columnIndex < BRICK_TYPE_GROUP * 4) {
			return BrickType.D;
		} else if (columnIndex < BRICK_TYPE_GROUP * 5) {
			return BrickType.E;
		} else if (columnIndex < BRICK_TYPE_GROUP * 6) {
			return BrickType.F;
		} else if (columnIndex < BRICK_TYPE_GROUP * 7) {
			return BrickType.G;
		} else
			return BrickType.H;

	}

	public void SaveGame(){
		playerS.save(bricksList);
	}

	public void SaveBrick(Brick bks){
		playerS.saveBrick (bks);
	}
}
