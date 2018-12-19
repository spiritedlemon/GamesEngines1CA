using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVehicle : MonoBehaviour {
	
	//Track if player is in Helicopter
	public static int engine = 0;

	void Awake()
	{
		//GameObject HelicopterCam =  GameObject.Find("VehicleCamera"); //FindVehicleCam game object
		//HelicopterCam.GetComponent<Camera>().enabled = false; //Disable helicopter camera on startup
		
	}
	// Use this for initialization
	void Start () 
	{
		//int engine = 0; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetKeyDown(KeyCode.E) && engine == 1)
		{
			Debug.Log ("Trying to leave Heli");
			
		}
		
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
			HelicopterGO.GetComponent<Rigidbody>().isKinematic = true; //Makes rigidbody kinematic making flying feel better
			
			GameObject Rotor = GameObject.Find("BladeMount"); //Find Helicopter Blades game object
			Rotor.GetComponent<RotateBlades>().enabled = true; //Enable Blades Spinning
			
			engine = 1;
			
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
