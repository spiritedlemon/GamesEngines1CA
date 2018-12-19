using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlying : MonoBehaviour {

	
	
	// Use this for initialization
	void Start () {
		//Debug.Log("Player in Helicopter");
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		var t = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * -8.0f;

        transform.Rotate(0, t, 0);
        transform.Translate(0, 0, z);
		
		
		//var p = Input.GetAxis("Vertical") * Time.deltaTime * 100.0f;
		//transform.Rotate(p, 0, 0);
		//Debug.Log(p);
		
		/*
		//Tilt helicopter in direction its moving 
		float x = Input.GetAxis("Vertical") * 15.0f; 
		Vector3 euler = transform.localEulerAngles;
		euler.x = Mathf.Lerp(euler.x, x, 1.0f * Time.deltaTime);
		transform.localEulerAngles = euler;
		*/
		
		if(Input.GetKey(KeyCode.Space))
		{
			//Debug.Log("Player going up");
			var h = 1 * Time.deltaTime * 8.0f;
			transform.Translate(0, h, 0);
			
		}
		
		if(Input.GetKey(KeyCode.LeftShift))
		{
			//Debug.Log("Player going down");
			var h = 1 * Time.deltaTime * -8.0f;
			transform.Translate(0, h, 0);
		}
		
		
	}
}
