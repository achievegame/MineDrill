using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BagHUDElement : MonoBehaviour {
	public bool isLocked = false;
	[SerializeField]
	private GameObject lockGO;
	[SerializeField]
	private Image e_img;
	[SerializeField]
	private Text e_count;

	public void init(Sprite eleImg, int count=1){
		e_img.gameObject.SetActive (true);
		e_img.sprite = eleImg;
		e_count.gameObject.SetActive (true);
		e_count.text = count.ToString();
	}

	public void init(bool isLocked){
		lockGO.SetActive (isLocked);
	}

	public void setCount(int count){
		e_count.text = count.ToString();
	}
}