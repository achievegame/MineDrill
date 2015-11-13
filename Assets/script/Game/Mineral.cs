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

	public void Active(){
		CircleCollider2D cc2d = gameObject.AddComponent<CircleCollider2D> ();
		cc2d.radius = 0.2f;
		gameObject.AddComponent<Rigidbody2D> ();
	}



	void OnCollisionEnter2D(Collision2D coll) {	
		if (coll.gameObject.CompareTag (Constants.TAG_PLAYER)) {
			MAudioManager.current.PlayFx(AudioName.MineralGrabSound);
			if(GameControl.current.AddMineral(mineralType)){
				StoreNMission.current.CollectMinerals(mineralType);
				Destroy(gameObject);
			}
		}
	} 
}
