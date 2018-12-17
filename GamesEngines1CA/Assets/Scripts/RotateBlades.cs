using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlades : MonoBehaviour {
	
	public float speed = 1000f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//GameObject Rotor =  GameObject.Find("BladeMount"); //Find Heli rotor blades
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
		
	}
}
