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
		
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * -100.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * -8.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
		
		if(Input.GetKey(KeyCode.Space))
		{
			Debug.Log("Player going up");
			var h = 1 * Time.deltaTime * 8.0f;
			transform.Translate(0, h, 0);
			
		}
		
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			Debug.Log("Player going down");
		}
		
		
	}
}
