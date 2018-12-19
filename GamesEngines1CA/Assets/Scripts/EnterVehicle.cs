using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVehicle : MonoBehaviour {
	
	//Track if player is in Helicopter
	public static int engine = 0;
	//Track if player is in range of helicopter
	public static int range = 0;
	//Store heli position
	Vector3 heliPos;

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
		if (Input.GetKeyDown(KeyCode.E))
        {
			
			
			if(engine == 1)
			{
				//Debug.Log ("Trying to leave Heli");
					
				GameObject PlayerCam =  GameObject.Find("PlayerCamera"); //Find playerCam game object
				PlayerCam.GetComponent<Camera>().enabled = true; //Enable Player camera
					
				GameObject PlayerGO = GameObject.FindWithTag("Player"); //Find player game object
				PlayerGO.GetComponent<PlayerMovement>().enabled = true; //Enable player movement
					
					
				GameObject HelicopterCam =  GameObject.Find("VehicleCamera"); //FindVehicleCam game object
				HelicopterCam.GetComponent<Camera>().enabled = false; //disable helicopter camera
					
				GameObject HelicopterGO = GameObject.FindWithTag("Vehicle"); //Find Helicopter game object
				HelicopterGO.GetComponent<PlayerFlying>().enabled = false; //disable player Flying (Helicopter)
				HelicopterGO.GetComponent<Rigidbody>().isKinematic = false; //Reenable rigidbody (Should maybe use charController for this)
					
				GameObject Rotor = GameObject.Find("BladeMount"); //Find Helicopter Blades game object
				Rotor.GetComponent<RotateBlades>().enabled = false; //disable Blades Spinning
				
				PlayerGO.transform.SetParent(null, false);
					
				engine = 0;
			}
			
			
			if(range == 1 && engine == 0)
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
				//HelicopterGO.transform.rotation = Quaternion.slerp(0, 0, 0);
				HelicopterGO.transform.rotation = new Quaternion(0, 0, 0, 0); //Set helicopter's rotation in case its on an incline
				
				GameObject Rotor = GameObject.Find("BladeMount"); //Find Helicopter Blades game object
				Rotor.GetComponent<RotateBlades>().enabled = true; //Enable Blades Spinning
				
				heliPos = HelicopterGO.transform.position;
				PlayerGO.transform.SetParent(HelicopterGO.transform, false); //Make player a child of helicopter
				PlayerGO.transform.position = heliPos; //Set player's position to that of helicopter
				
				engine = 1;
				
			
			}
			
			
        }
		
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			//when player comes in range it is set to 1 (True)
			range = 1;
		}
	}
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			range = 0;
		}
		//Debug.Log ("Leaving trigger");
	}
	
	/*
	void OnTriggerStay (Collider other)
	{
		//Debug.Log ("In trigger");
		
		
	}
	*/
	
	/*
	
	
	
	*/
}
