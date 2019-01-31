using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 7f;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;
    void FixedUpdate ()
    {
        currentRotation.x += Input.GetAxis ( "Mouse X" ) * sensitivity;
        currentRotation.y -= Input.GetAxis ( "Mouse Y" ) * sensitivity;
        currentRotation.x = Mathf.Repeat ( currentRotation.x, 360 );
        currentRotation.y = Mathf.Clamp ( currentRotation.y, -maxYAngle, maxYAngle );
        transform.localRotation = Quaternion.Euler ( currentRotation.y, 0, 0 );
        transform.parent.rotation = Quaternion.Euler ( 0, currentRotation.x, 0 );
        if ( Input.GetMouseButtonDown ( 0 ) )
            Cursor.lockState = CursorLockMode.Locked;
    }
}