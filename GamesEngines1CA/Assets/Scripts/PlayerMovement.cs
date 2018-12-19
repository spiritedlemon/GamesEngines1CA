using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	
    [SerializeField] private float movementSpeed; //Makes it easy to adjust speed

    private CharacterController charController;

    private bool isJumping;

	// Use this for initialization
    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

	// Update is called once per frame
    private void Update()
    {
        CharMove();
		
		//var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 8.0f;

        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);
		
		
		/*
		if (Input.GetKeyDown(KeyCode.E))
        {
            print("Enter vehicle key was pressed");
        }
		*/
    }

    private void CharMove()
    {
        float horizInput = Input.GetAxis("Horizontal") * movementSpeed;
        float vertInput = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

    }

    

}