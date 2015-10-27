using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour {

	[SerializeField]
	private List<AnimatorOverrideController> animators = new List<AnimatorOverrideController>();
//	[SerializeField]
//	private List<Sprite> sprites = new List<Sprite>();
	const string CHARACTER_KEY = "animine_character_key";

	void OnDestroy(){
		GameControl.OnCharecterChanged -= HandleOnCharecterChanged;
	}

	void Start(){
		GameControl.OnCharecterChanged += HandleOnCharecterChanged;
		HandleOnCharecterChanged (PlayerPrefs.GetInt(CHARACTER_KEY,0));
	}

	void HandleOnCharecterChanged (int index)
	{
		PlayerPrefs.SetInt (CHARACTER_KEY, index);
		//SpriteRenderer spr = GetComponent<SpriteRenderer> ();
		//spr.sprite = sprites [index];
		Animator animator = GetComponent<Animator>();		
		animator.runtimeAnimatorController = animators[index];
	}
}
