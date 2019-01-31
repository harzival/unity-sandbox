using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private int groundedCounter = 3;
    private Rigidbody rigidBody;

    void Start ()
    {
        rigidBody = GetComponent<Rigidbody> ();
    }

    void FixedUpdate ()
    {
        rigidBody.velocity = ( GetDirection () * GetSpeed () ) + GetJumpForce ();
    }

    private Vector3 GetDirection ()
    {
        Vector3 direction = new Vector3 ();
        if ( Input.GetKey ( KeyCode.W ) )
            direction += transform.forward;
        if ( Input.GetKey ( KeyCode.S ) )
            direction += -transform.forward;
        if ( Input.GetKey ( KeyCode.A ) )
            direction += -transform.right;
        if ( Input.GetKey ( KeyCode.D ) )
            direction += transform.right;
        return direction;
    }
    private float GetSpeed ()
    {
        if ( Input.GetKey ( KeyCode.LeftShift ) )
            return 10.0F;
        return 5.0F;
    }
    private Vector3 GetJumpForce ()
    {
        float currentJumpForce = rigidBody.velocity.y;
        Vector3 jumpForce = new Vector3 ( 0.0F, currentJumpForce, 0.0F );
        if ( IsGrounded() )
            if ( Input.GetKeyDown ( KeyCode.Space ) )
                jumpForce.y += 5.0F;
        return jumpForce;
    }
    // Function to check if the player is standing on a surface.
    // Some methods of doing this involve casting a ray downwards
    // to detect the distance between player and the surface below
    // them. It becomes complicated when your on a slanted surface,
    // one with holes, etc.
    // To keep it really simple, my method just checks if the speed of
    // the player on the Y axis hasn't gone above a threshold for a
    // specified number of fixed updates (groundedCounter).
    private bool IsGrounded ()
    {
        Vector3 yVelocity = new Vector3 ( 0, rigidBody.velocity.y, 0 );
        if ( yVelocity.magnitude < 0.01F )
        {
            if ( groundedCounter != 0 )
                groundedCounter = groundedCounter - 1;
        }
        else
            groundedCounter = 3;
        if ( groundedCounter <= 0 )
            return true;
        return false;

    }
}