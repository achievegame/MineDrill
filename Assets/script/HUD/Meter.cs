using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour {
	[SerializeField]
	private GameObject Arrow;
	public float Value {
		set {
			Arrow.transform.localRotation = Quaternion.Euler(0,0,-90+180*value);
		}
	}


}
