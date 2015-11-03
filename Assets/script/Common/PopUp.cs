using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour {

	public void Close(){
		Destroy (gameObject);
	}

	public void LoadHUD(string hudName){
		GameObject hudPF = Resources.Load<GameObject> (Constants.RESOURCELOCATION_PREFAB+hudName);
		GameObject hudGO = (GameObject)Instantiate (hudPF);
	}
}
