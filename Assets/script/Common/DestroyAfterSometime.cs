using UnityEngine;
using System.Collections;

public class DestroyAfterSometime : MonoBehaviour {

	[SerializeField]
	private float delay=1f;
	// Use this for initialization
	void Start () {
		Invoke ("DestroyIt", delay);
	}	

	void DestroyIt(){
		Destroy (gameObject);
	}

}
