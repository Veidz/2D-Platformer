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

    [Header("Animation Player")]
    public string boolRun = "Run";
    private Animator playerAnimator;
    public float playerSwipeDuration = 0.05f;

    private float _currentSpeed;

    private void Start()
    {
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.velocity = new Vector2(-_currentSpeed, playerRigidbody.velocity.y);

            if (playerRigidbody.transform.localScale.x != -1)
            {
                playerRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }

            playerAnimator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidbody.velocity = new Vector2(_currentSpeed, playerRigidbody.velocity.y);

            if (playerRigidbody.transform.localScale.x != 1)
            {
                playerRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }

            playerAnimator.SetBool(boolRun, true);
        }
        else
        {
            playerAnimator.SetBool(boolRun, false);
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
            playerRigidbody.velocity = Vector2.up * forceJump;
            playerRigidbody.transform.localScale = Vector2.one;

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
