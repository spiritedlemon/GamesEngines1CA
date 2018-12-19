using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicsSpawner : MonoBehaviour {
    public GameObject HeliPrefab;
    public GameObject player;

    public LayerMask groundLM;
    

    void SpawnHeli(Vector3 point, Quaternion q)
    {
        GameObject heli = GameObject.Instantiate<GameObject>(HeliPrefab, point, q);

    }
	
	// Update is called once per frame
	void Update () 
	{
		
		//On f press - Spawn helicopter
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit rch;
            if (Physics.Raycast(player.transform.position, player.transform.forward, out rch, 100, groundLM))
            {
                Vector3 p = rch.point;
                p.y = 5;
                Quaternion q = player.transform.rotation;
                Vector3 xyz = q.eulerAngles;
                q = Quaternion.Euler(0, xyz.y + 90, 0);
                SpawnHeli(p, q);
            }
        } 

		
		if (Input.GetKeyDown (KeyCode.T) )
		{
			SceneManager.LoadScene("FlightSim");
			
		}
    }
}
