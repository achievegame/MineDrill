using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class HUD : MonoBehaviour {

	public void LoadAgain(){
		Application.LoadLevel (Application.loadedLevel);
	}
}
