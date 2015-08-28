using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour {
	public ToggleButtonChanged OnToggleButtonChanged; 
	[SerializeField]
	private Sprite toggleOn;
	[SerializeField]
	private Sprite toggleOff;
	[SerializeField]
	private Sprite toggleOnPressed;
	[SerializeField]
	private Sprite toggleOffPressed;
	[SerializeField]

	private Button button;

	[SerializeField]
	private bool _isOn=true;
	private Image targetGraphic;
	private SpriteState sState;

	public bool isOn {
		get {
			return _isOn;
		}
		set {
			_isOn = value;
			targetGraphic.sprite = (_isOn)?toggleOn:toggleOff;
			sState.pressedSprite = (_isOn)?toggleOnPressed:toggleOffPressed;
			if(OnToggleButtonChanged!=null)
				OnToggleButtonChanged();
		}
	}

	void Start(){
		targetGraphic = button.targetGraphic.GetComponent<Image>();
		sState = button.spriteState;
		button.onClick.AddListener (() => {
			isOn=!isOn;
		});

		targetGraphic.sprite = (_isOn)?toggleOn:toggleOff;
		sState.pressedSprite = (_isOn)?toggleOnPressed:toggleOffPressed;
	}

}
