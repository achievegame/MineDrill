using UnityEngine;
using System.Collections;

public class SavaData : MonoBehaviour {

	public static SavaData current;
	
	void Awake()
	{
		//if we don't currently have a game control...
		if (current == null)
			//...set this one to be it...
			current = this;
		//...otherwise...
		else if(current != this)
			//...destroy this one because it is a duplicate
			Destroy (gameObject);
	
	}
}
