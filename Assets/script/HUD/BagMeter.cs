using UnityEngine;
using System.Collections;

public class BagMeter : Meter {
	// Use this for initialization
	void Start () {
		GameControl.OnMineralAdded += OnMineralAdded;
		OnMineralAdded ();
	}

	void OnEnable(){
		OnMineralAdded ();
	}

	void OnDestroy(){
		GameControl.OnMineralAdded -= OnMineralAdded;
	}

	private void OnMineralAdded(){
		Value = GameControl.current.BagMeterValue;
	}
}
