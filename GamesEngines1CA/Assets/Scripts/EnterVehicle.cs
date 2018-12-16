﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVehicle : MonoBehaviour {

	void Awake()
	{
		//GameObject HelicopterCam =  GameObject.Find("VehicleCamera"); //FindVehicleCam game object
		//HelicopterCam.GetComponent<Camera>().enabled = false; //Disable helicopter camera on startup
		
	}
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
            //print("Player Movement and camera are disabled");
			
			GameObject PlayerCam =  GameObject.Find("PlayerCamera"); //Find playerCam game object
			PlayerCam.GetComponent<Camera>().enabled = false; //Disable Player camera
			
			GameObject PlayerGO = GameObject.FindWithTag("Player"); //Find player game object
			PlayerGO.GetComponent<PlayerMovement>().enabled = false; //Disable player movement
			
			
			GameObject HelicopterCam =  GameObject.Find("VehicleCamera"); //FindVehicleCam game object
			HelicopterCam.GetComponent<Camera>().enabled = true; //Enable helicopter camera
			
			GameObject HelicopterGO = GameObject.FindWithTag("Vehicle"); //Find Helicopter game object
			HelicopterGO.GetComponent<PlayerFlying>().enabled = true; //Enable player Flying (Helicopter)
			
			GameObject Rotor = GameObject.Find("BladeMount"); //Find Helicopter Blades game object
			Rotor.GetComponent<RotateBlades>().enabled = true; //Enable Blades Spinning
			
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