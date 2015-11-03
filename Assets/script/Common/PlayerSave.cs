using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

[System.Serializable]
public class PlayerSave
{
	public List<BrickSave> bricks = new List<BrickSave>();
    public void save(List<Brick> bricksGO)
    {
		BrickSave bSv;
		foreach(Brick bks in bricksGO){
			if(bks.canSave){
				bSv = bricks[bks.id];
				bSv.drilledAmount = bks.drilledAmount;
				bSv.mineralType = bks.mineralType;
				bSv.neighbourCode = bks.neighbourCode;
				//Debug.Log("bSv.id:"+bSv.id);
			}
		}

		commit ();
    }

	public void saveBrick(Brick bks){
		BrickSave bSv = bricks[bks.id];
		bSv.drilledAmount = bks.drilledAmount;
		bSv.mineralType = bks.mineralType;
		bSv.neighbourCode = bks.neighbourCode;
	}

	public void commit(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/" + Constants.USER_DATA_FILE);
		bf.Serialize(file, this);
		file.Close();
	}   
  
    public static PlayerSave load()
    {
        PlayerSave result;
        if (File.Exists(Application.persistentDataPath + "/" + Constants.USER_DATA_FILE))
        {
            Debug.Log("BinaryFormatter bf = new BinaryFormatter();");
            BinaryFormatter bf = new BinaryFormatter();
            //Debug.Log("FileStream file = File.Open(Application.persistentDataPath" + "/" + Constants.USER_DATA_FILE + ", FileMode.Open);");
            FileStream file = File.Open(Application.persistentDataPath + "/" + Constants.USER_DATA_FILE, FileMode.Open);
            //Debug.Log("PlayerSaveState.savedGames");
            result = (PlayerSave)bf.Deserialize(file);
            //Debug.Log("file.close");
            file.Close();
        }
        else
        {
            result = initFirstPlay(); // hack for testing
        }

        return result;

		//return initFirstPlay();
    }

	public static PlayerSave loadNew(){
		return initFirstPlay ();
	}

    static PlayerSave initFirstPlay()
    {
        PlayerSave s = new PlayerSave();
		BrickSave brick;
		int ROW = 161;
		int COLUMN = 50;
		for (int i=0; i<ROW; i++) {
			for(int j=0; j<COLUMN; j++){
				brick = new BrickSave();
				brick.id = i*COLUMN+j;
				brick.brickType = (BrickType)getBrickType(i);
				brick.drilledAmount = 0;
				brick.neighbourCode = i*COLUMN+j<COLUMN ? "1011":"1111";				
				//add minerals
				if(i==ROW-1 || (i == 0 && j >= 22 && j <= 27)){
					//last row, cant be drilled
					brick.mineralType = MineralType.NonBreakableStone;
				}else if(UnityEngine.Random.value <0.1f){
					brick.mineralType = (MineralType)UnityEngine.Random.Range(0,9);
				}
				s.bricks.Add(brick);
			}
		}
		//first commit
		s.commit ();

        return s;
    }
	public const int BRICK_TYPE_GROUP = 20;
	static private int getBrickType(int columnIndex){
		if (columnIndex < BRICK_TYPE_GROUP) {
			return 0;
		} else if (columnIndex < BRICK_TYPE_GROUP * 2) {
			return 1;
		} else if (columnIndex < BRICK_TYPE_GROUP * 3) {
			return 2;
		} else if (columnIndex < BRICK_TYPE_GROUP * 4) {
			return 3;
		} else if (columnIndex < BRICK_TYPE_GROUP * 5) {
			return 4;
		} else if (columnIndex < BRICK_TYPE_GROUP * 6) {
			return 5;
		} else if (columnIndex < BRICK_TYPE_GROUP * 7) {
			return 6;
		} else
			return 7;
		
	}
}
