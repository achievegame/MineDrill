using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml;

[RequireComponent (typeof (Text))]
public class LanguageElement : MonoBehaviour {
	Text textElement;
	public LanguageTextType textType = LanguageTextType.Text_Normal;
	public LanguageNode langNode;

	void OnDestroy(){
		LanguageManager.OnLanguageChanged -= OnLanguageChanged;
	}

	void Awake(){
		textElement = GetComponent<Text> ();
		if (textType == LanguageTextType.Text_Urgent || textType == LanguageTextType.Text_Ignore_Urgent) {
			LanguageManager.OnLanguageChanged += OnLanguageChanged;
		}
	}

	void Start () {
		setText ();			
	}

	public void setText(){
		textElement.font = LanguageManager.current.getFont ();
		if (textType == LanguageTextType.Text_Normal || textType == LanguageTextType.Text_Urgent) {
			textElement.text = LanguageManager.current.getText (langNode);
		}
	}
	
	void OnLanguageChanged(){
		setText ();
	}
}
