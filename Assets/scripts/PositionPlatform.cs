﻿using UnityEngine;
using System.Collections;

public class PositionPlatform : MonoBehaviour
{
	
	/***********************************************/
	public int angleRotation = 90;
	public float targetAngle = 0;
	public bool isAnimed = false;
	/***********************************************/
	public float smooth = 20.0F;
	
	private GameObject gPivot;
	
	// Use this for initialization
	void Start()
	{
		gPivot = GameObject.FindWithTag("center");
	}
	
	// Update is called once per frame
	void Update()
	{
		loadPivot ();
		
		if (Input.GetKey ("up") && !isAnimed) {
			isAnimed = true;
			
		}
		if (Input.GetKey("up") && !isAnimed) {
			isAnimed =  true;
			
		}
		
		if (isAnimed) {
			transform.RotateAround (gPivot.transform.position, new Vector3 (0, 0, 1), smooth * Time.deltaTime);
			GetComponent<Rigidbody2D> ().gravityScale = 0;
		} else {
			GetComponent<Rigidbody2D> ().gravityScale = 1;
		}
		
		targetAngle = transform.rotation.eulerAngles.z;
		
		if (targetAngle <= (angleRotation + 1) && targetAngle >= (angleRotation - 1))
		{
			transform.RotateAround(gPivot.transform.position, Vector3.forward, 0);
			if(targetAngle > 359){
				angleRotation = 0;
				
			}else{
				angleRotation +=90; 
				
			}
			isAnimed = false;
		}
	}
	
	void loadPivot()
	{
		foreach (BoxCollider2D childCompnent in GetComponentsInChildren<BoxCollider2D>())
			childCompnent.enabled = false;
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			gPivot = GameObject.FindWithTag("top");
			
		}else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			gPivot = GameObject.FindWithTag("right");
			
		}else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			gPivot = GameObject.FindWithTag("bottom");
			
		}else if (Input.GetKeyDown(KeyCode.Alpha4)) {
			gPivot = GameObject.FindWithTag("left");
			
		}else if (Input.GetKeyDown(KeyCode.Alpha0)) {
			gPivot = GameObject.FindWithTag("center");
			
		}
		if(!isAnimed){
			gPivot.GetComponent<BoxCollider2D>().enabled = true;
		}
	}
}