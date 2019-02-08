using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolGunController : MonoBehaviour
{
    public Transform playerHead;
    private Vector3 playerHeadDirection;
    private Ray playerGaze;
    private RaycastHit playerGazeHit;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        playerHeadDirection = playerHead.transform.TransformDirection ( Vector3.forward ) * 10;
        playerGaze = new Ray ( playerHead.position, playerHeadDirection );
        if ( Physics.Raycast ( playerGaze, out playerGazeHit ) )
        {
            Ray gunAim = new Ray ( transform.parent.position, ( playerGazeHit.point - transform.position ) );
            transform.parent.forward = transform.parent.InverseTransformDirection ( gunAim.direction );
            transform.parent.LookAt ( playerGazeHit.point, Vector3.up );
        }
        if ( Input.GetMouseButtonDown ( 0 ) )
        {


        }

    }
}
