using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float moveSpeed = 2f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }
    }

    // USED IN MOVING PLATFORMS IN ORDER TO MOVE THE PLAYER 
    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
}
