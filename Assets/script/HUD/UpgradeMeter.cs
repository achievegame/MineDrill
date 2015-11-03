using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeMeter : MonoBehaviour {

	[SerializeField]
	private Image upgdMeter;

	public float fillAmount{
		get{
			return upgdMeter.fillAmount;
		}
		set{
			upgdMeter.fillAmount = value;
		}
	}
}
