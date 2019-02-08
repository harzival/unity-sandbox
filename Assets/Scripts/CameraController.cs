using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 7f;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;
    public Transform playerArm;
    private PlayerController playerController;
    void Start() 
    {
        playerController = GetComponentInParent<PlayerController> (); 
    }

    void FixedUpdate ()
    {
        if ( playerController.moveEnabled ) 
        {
            currentRotation.x += Input.GetAxis ( "Mouse X" ) * sensitivity;
            currentRotation.y -= Input.GetAxis ( "Mouse Y" ) * sensitivity;
            currentRotation.x = Mathf.Repeat ( currentRotation.x, 360 );
            currentRotation.y = Mathf.Clamp ( currentRotation.y, -maxYAngle, maxYAngle );
            transform.localRotation = Quaternion.Euler ( currentRotation.y, 0, 0 );
            transform.parent.rotation = Quaternion.Euler ( 0, currentRotation.x, 0 );
            //playerArm.localRotation = Quaternion.Euler ( currentRotation.y - 100, 0, 0 );
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private static float WrapAngle ( float angle )
    {
        angle %= 360;
        if ( angle > 180 )
            return angle - 360;

        return angle;
    }
}