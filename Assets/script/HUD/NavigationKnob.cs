using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class NavigationKnob : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler{
	private RectTransform knobRect;
	private const float MAX_DISTANCE = 47;
	//private float MAX_DISTANCE_RATIO = 1f/MAX_DISTANCE;
	private float ONE_BY_45 = 1f / 45;
	void Start(){
		knobRect = transform as RectTransform;
	}
	public Vector2 velocity(){
		if (!knobRect || knobRect.localPosition == Vector3.zero) {
			return Vector2.zero;
		}
		float angle = Mathf.Atan2 (knobRect.localPosition.y,knobRect.localPosition.x);
		int dir = Mathf.FloorToInt ((angle * Mathf.Rad2Deg + 22.5f) * ONE_BY_45);
		switch (dir) {
			case 0:
				return Vector2.right;
			case 1: 
				return Vector2.one;
			case 2:
				return Vector2.up;
			case 3:
				return new Vector2(-1,1);
			case 4:
			case -4:
				return Vector2.left;
			case -3:
				return new Vector2(-1,-1);
			case -2:
				return Vector2.down;
			case -1:
				return new Vector2(1,-1);
			default:
			return Vector2.zero;
		}
	}


	public void OnPointerUp (PointerEventData eventData)
	{
		StartCoroutine (GoCenter());
	}


	public void OnPointerDown (PointerEventData eventData)
	{

	}

	public void OnDrag (PointerEventData eventData)
	{
		Vector2 parentPos = transform.parent.transform.position;
		Vector2 localPos = (Vector2)Input.mousePosition - parentPos;
		localPos = Vector2.ClampMagnitude(localPos,MAX_DISTANCE);
		knobRect.localPosition = new Vector2 (localPos.x,localPos.y);
	}

	IEnumerator GoCenter(){
		bool notCenter = true;
		Vector2 localPos = knobRect.localPosition;
		float distToCenter = localPos.magnitude;
		knobRect.localPosition = new Vector2 (localPos.x,localPos.y);
		while (notCenter) {
			knobRect.localPosition = Vector2.ClampMagnitude(localPos,distToCenter);
			distToCenter=Mathf.Lerp(distToCenter,0,0.7f);
			if(Mathf.Abs(distToCenter) <= 5f){
				knobRect.localPosition = Vector2.zero;
				notCenter=false;
			}else{
				yield return new WaitForSeconds(Time.deltaTime);
			}
		}
	}
}
