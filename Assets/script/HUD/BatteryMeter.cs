using UnityEngine;
using System.Collections;

public class BatteryMeter : MonoBehaviour {
	public Meter mtr;
	// Use this for initialization
	void Start () {
	
	}
	float value =1.0f;
	void Update(){
		if (value <= 0) {
			value = 1f;
		}
		value -= Time.deltaTime*0.1f;
		mtr.Value = value;
	}

}
