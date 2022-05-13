using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(0.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;


    [Header("Animation setup")]
    public float jumpScaleY = 3f;
    public float jumpScaleX = 1.5f;
    public float animationDuration = 0.2f;
    public Ease ease = Ease.OutBack;

    private float _currentSpeed;

    private void Update()
    {
        HandleWalk();
        HandleRun();
        HandleJump();
    }

    private void HandleWalk()
    {
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

    private void HandleRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.velocity = Vector2.up * forceJump;
            playerRigidbody.transform.localScale = Vector2.one * 2;

            DOTween.Kill(playerRigidbody.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        playerRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        playerRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
