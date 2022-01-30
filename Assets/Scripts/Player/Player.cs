using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;

    private float _currentSpeed;

    private void Update()
    {
        HandleJump();
        HandleWalk();
    }

    private void HandleWalk()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.velocity = new Vector2(-_currentSpeed, playerRigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidbody.velocity = new Vector2(_currentSpeed, playerRigidbody.velocity.y);
        }

        if (playerRigidbody.velocity.x > 0)
        {
            playerRigidbody.velocity += friction;
        }
        else if (playerRigidbody.velocity.x < 0)
        {
            playerRigidbody.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.velocity = Vector2.up * forceJump;
        }
    }
}
