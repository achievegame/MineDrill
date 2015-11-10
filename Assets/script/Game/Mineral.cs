using UnityEngine;
using System.Collections;

public class Mineral : MonoBehaviour {
	private MineralType mineralType = MineralType.Coal;
	private SpriteRenderer spr;

	public void init(MineralType mineralType){
		this.mineralType = mineralType;
		spr = GetComponent<SpriteRenderer> ();
		spr.sprite = BrickManager.current.Minerals[(int)mineralType];
	}



	void OnCollisionEnter2D(Collision2D coll) {	
		if (coll.gameObject.CompareTag (Constants.TAG_PLAYER)) {
			MAudioManager.current.PlayFx(AudioName.MineralGrabSound);
			StoreNMission.current.CollectMinerals(mineralType);
			if(GameControl.current.AddMineral(mineralType)){
				Destroy(gameObject);
			}
		}
	} 
}
