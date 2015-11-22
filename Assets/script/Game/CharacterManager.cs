using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour {

	[SerializeField]
	private List<AnimatorOverrideController> animators = new List<AnimatorOverrideController>();


	void OnDestroy(){
		GameControl.OnCharecterChanged -= HandleOnCharecterChanged;
	}

	void Start(){
		GameControl.OnCharecterChanged += HandleOnCharecterChanged;
		HandleOnCharecterChanged (GameControl.current.characterIndex);
	}

	void HandleOnCharecterChanged (int index)
	{
		Animator animator = GetComponent<Animator>();		
		animator.runtimeAnimatorController = animators[index];
	}
}
