using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour {

	private bool busy = false;
	private void setBusyFalse(){
		busy = false;
	}
	
	protected bool isBusy{
		get{
			if (busy) {
				return true;
			}
			
			busy = true;
			Invoke ("setBusyFalse",0.5f);
			return false;
		}
	}

	public void Close(){
		Destroy (gameObject);
	}

	public void LoadHUD(string hudName){
		GameObject hudPF = Resources.Load<GameObject> (Constants.RESOURCELOCATION_PREFAB+hudName);
		Instantiate (hudPF);
	}
}
