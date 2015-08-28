using UnityEngine;
using System.Collections;

public class GoMainScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (goMainScreen(6f));
	}
	
	IEnumerator goMainScreen(float delay){
		yield return new WaitForSeconds(delay);
		//Application.LoadLevel (SceneName.Main.ToString());
	}
}
