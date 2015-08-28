using UnityEngine;
using System.Collections;

public class ChangeAspectRatio : MonoBehaviour {

	// Use this for initialization

	private static float newOSize;
	void Start () {
		newOSize = 8.89f * Screen.height / Screen.width;
		if (newOSize-5 < 0.01f)
			return;
		Camera.main.GetComponent<Camera>().orthographicSize = newOSize;
		Camera.main.GetComponent<Camera>().transform.position = new Vector3 (Camera.main.GetComponent<Camera>().transform.position.x,(5-newOSize),Camera.main.GetComponent<Camera>().transform.position.z);
	}

	public static void setAspectRatioNormal(bool normal){
		if (normal) {
			Camera.main.GetComponent<Camera>().orthographicSize = 5;
			Camera.main.GetComponent<Camera>().transform.position = new Vector3 (Camera.main.GetComponent<Camera>().transform.position.x,0,Camera.main.GetComponent<Camera>().transform.position.z);	
		} else {
			Camera.main.GetComponent<Camera>().orthographicSize = newOSize;
			Camera.main.GetComponent<Camera>().transform.position = new Vector3 (Camera.main.GetComponent<Camera>().transform.position.x,(5-newOSize),Camera.main.GetComponent<Camera>().transform.position.z);	
		}
	}
}
