﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVehicle : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	
	
	void OnTriggerStay (Collider other)
	{
		//Debug.Log ("In trigger");
		if (Input.GetKeyDown(KeyCode.E))
        {
            print("Enter vehicle key was pressed");
        }
	}
	
	
	/*
	
	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Entered trigger");
	}
	void OnTriggerExit (Collider other)
	{
		Debug.Log ("Leaving trigger");
	}
	
	*/
}
