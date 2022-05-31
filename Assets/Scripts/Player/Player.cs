using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRB;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(-0.3f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 20f;
    private float playerMove;


    [Header("Animation setup")]
    public float jumpScale = 1.1f;
    public float animationDuration = 0.3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    private Animator playerAnimator;
    public float playerSwipeDuration = 0.05f;

    private float _currentSpeed;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        HandleWalk();
        HandleRun();
        HandleJump();
    }

    private void HandleWalk()
    {
        playerMove = Input.GetAxis("Horizontal");

        Debug.Log(playerMove);

        if (playerMove < 0)
        {
            // Left
            playerRB.velocity = new Vector2(-_currentSpeed, playerRB.velocity.y);

            if (playerRB.transform.localScale.x != -1)
            {
                playerRB.transform.DOScaleX(-1, playerSwipeDuration);
            }

            playerAnimator.SetBool(boolRun, true);
        }
        else if (playerMove > 0)
        {
            // Right
            playerRB.velocity = new Vector2(_currentSpeed, playerRB.velocity.y);

            if (playerRB.transform.localScale.x != 1)
            {
                playerRB.transform.DOScaleX(1, playerSwipeDuration);
            }

            playerAnimator.SetBool(boolRun, true);
        }
        else
        {
            // Idle
            playerAnimator.SetBool(boolRun, false);
        }

        if (playerRB.velocity.x > 0)
        {
            playerRB.velocity += friction;
        }
        else if (playerRB.velocity.x < 0)
        {
            playerRB.velocity -= friction;
        }
    }

    private void HandleRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
            playerAnimator.speed = 1.25f;
        }
        else
        {
            _currentSpeed = speed;
            playerAnimator.speed = 1;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.velocity = Vector2.up * forceJump;
            playerRB.transform.localScale = Vector2.one;

            DOTween.Kill(playerRB.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        playerRB.transform.DOScale(jumpScale, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
