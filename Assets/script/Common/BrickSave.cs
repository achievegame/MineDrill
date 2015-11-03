using UnityEngine;
using System.Collections;

[System.Serializable]
public class BrickSave
{
	public int id;
	public BrickType brickType=BrickType.A;
	//public int brickType;
	public int drilledAmount=0;
	//public int mineralType=-1;
	public MineralType mineralType = MineralType.None;
	public string neighbourCode;
}

