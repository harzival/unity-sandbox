using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolGunController : MonoBehaviour
{
    public Transform playerHead;
    public Ray gunAimRay;
    public RaycastHit playerGazeHit;

    private ObjectSpawnerTool objectSpawnerTool;
    private Vector3 playerHeadDirection;
    private Ray playerGaze;

    void Start()
    {
        gameObject.tag = "toolGun";
        objectSpawnerTool = gameObject.GetComponent<ObjectSpawnerTool> ();
    }

    void Update()
    {
        playerHeadDirection = playerHead.transform.TransformDirection ( Vector3.forward ) * 10;
        playerGaze = new Ray ( playerHead.position, playerHeadDirection );
        if ( Physics.Raycast ( playerGaze, out playerGazeHit, 100, LayerMask.GetMask ( "Default" ) ) )
        {
            gunAimRay = new Ray ( transform.parent.position, ( playerGazeHit.point - transform.position ) );
            transform.parent.LookAt ( playerGazeHit.point );
        }


    }
}
