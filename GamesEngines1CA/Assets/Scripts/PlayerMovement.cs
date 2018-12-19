using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	
    [SerializeField] private float movementSpeed; //Makes it easy to adjust speed

    private CharacterController charController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;


    private bool isJumping;

	// Use this for initialization
    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

	// Update is called once per frame
    private void Update()
    {
        PlayerMovement();
		
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

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis("Horizontal") * movementSpeed;
        float vertInput = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

        JumpInput();

    }

    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }

}