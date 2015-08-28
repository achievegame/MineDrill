﻿using UnityEngine;
using System.Collections;

public class mPlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool	facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool	jump = false;				// Condition for whether the player should jump.


	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
	private Rigidbody2D r2d;
	public NavigationKnob NK;

	private Transform mTransform;

	void Awake ()
	{
		// Setting up references.
		mTransform = transform;
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
		r2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(mTransform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  

	}

	void FixedUpdate ()
	{
		// Cache the horizontal input.
		//float h = Input.GetAxis("Horizontal");
		//float v = Input.GetAxis ("Vertical");


		Vector2 knobV = NK.velocity ();
		if (knobV == Vector2.zero) {
			r2d.velocity = new Vector2(0,r2d.velocity.y);
			anim.SetTrigger("Default");
			return;
		}
			

		float h = knobV.x;
		float v = knobV.y;


		if (h != 0 && grounded) {
			anim.SetTrigger ("Walking");
		} else {
			anim.SetTrigger("Default");
		}



		if (r2d.velocity.sqrMagnitude > maxSpeed * maxSpeed)
			r2d.velocity = knobV * maxSpeed;
		else {
			if (!grounded && v ==0) {
				knobV.x=0;
			}
			r2d.AddForce (knobV * moveForce);
		}

		if ( h < 0 && facingRight || h > 0 && !facingRight)
			Flip ();

		if (grounded && r2d.velocity == Vector2.zero) {
			int columnNo = Mathf.FloorToInt(mTransform.position.x*BrickManager.ONE_BY_GRID_WIDTH+0.5f);
			int rowNo = Mathf.FloorToInt(mTransform.position.y*BrickManager.ONE_BY_GRID_WIDTH+3.5f);//beneath box row
			//Debug.Log("rowNo:"+rowNo+" columnNo:"+columnNo);
			if(v == -1 && h == 0){
				mTransform.position = new Vector2(columnNo*BrickManager.GRID_WIDTH, mTransform.position.y);
				BrickManager.current.Drilling(-rowNo,columnNo, RelativeDirection.Top);
			}else if(v==0 && h==1){
				BrickManager.current.Drilling(-rowNo-1,columnNo+1, RelativeDirection.Left);
			}else if(v==0 && h==-1){
				BrickManager.current.Drilling(-rowNo-1,columnNo-1, RelativeDirection.Right);
			}				
		}
	}
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = mTransform.localScale;
		theScale.x *= -1;
		mTransform.localScale = theScale;
	}
}
