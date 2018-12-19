using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCameraControl : MonoBehaviour {

    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    private float xAxisLimit;

    private void Awake()
    {
        LockCursor();
		//Limit will be used to stop the player looking up/down more than 90'
        xAxisLimit = 0.0f; 
    }


    private void LockCursor()
    {
		//locks cursor to centre of view (and invisible, press [escape] to make re-appear)
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xAxisLimit += mouseY;

        if(xAxisLimit > 90.0f)
        {
            xAxisLimit = 90.0f;
            mouseY = 0.0f;
            LimitXAxisRotationToValue(270.0f);
        }
        else if (xAxisLimit < -90.0f)
        {
            xAxisLimit = -90.0f;
            mouseY = 0.0f;
            LimitXAxisRotationToValue(90.0f);
        }

		//For turning the body and not just the camera:
        transform.Rotate(Vector3.left * mouseY);
        //playerBody.Rotate(Vector3.up * mouseX);
    }

    private void LimitXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}