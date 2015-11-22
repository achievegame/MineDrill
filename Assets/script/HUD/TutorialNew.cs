using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialNew : PopUp {
	[SerializeField]
	private Sprite[] slides;
	[SerializeField]
	private Image slideView;

	private int slideIndex = 0;

	void Start(){
		slideView.sprite = slides[slideIndex];
	}

	public void NextSlide(){
		slideView.sprite = slides[++slideIndex];
		if(slideIndex == 5)
			slideIndex=0;
	}

}
