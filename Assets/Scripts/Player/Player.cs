using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public HealthBase healthBase;

    [Header("Setup")]
    public SOPlayer soPlayer;

    private float playerMove;
    private Animator playerAnimator;
    private float _currentSpeed;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;   
        }
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        playerAnimator.SetTrigger(soPlayer.triggerDeath);
    }

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

        if (playerMove < 0)
        {
            // Left
            playerRB.velocity = new Vector2(-_currentSpeed, playerRB.velocity.y);

            if (playerRB.transform.localScale.x != -1)
            {
                playerRB.transform.DOScaleX(-1, soPlayer.playerSwipeDuration);
            }

            playerAnimator.SetBool(soPlayer.boolRun, true);
        }
        else if (playerMove > 0)
        {
            // Right
            playerRB.velocity = new Vector2(_currentSpeed, playerRB.velocity.y);

            if (playerRB.transform.localScale.x != 1)
            {
                playerRB.transform.DOScaleX(1, soPlayer.playerSwipeDuration);
            }

            playerAnimator.SetBool(soPlayer.boolRun, true);
        }
        else
        {
            // Idle
            playerAnimator.SetBool(soPlayer.boolRun, false);
        }

        if (playerRB.velocity.x > 0)
        {
            playerRB.velocity += soPlayer.friction;
        }
        else if (playerRB.velocity.x < 0)
        {
            playerRB.velocity -= soPlayer.friction;
        }
    }

    private void HandleRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = soPlayer.speedRun;
            playerAnimator.speed = 1.25f;
        }
        else
        {
            _currentSpeed = soPlayer.speed;
            playerAnimator.speed = 1;
        }
    }

    private void HandleJump()
    {
        playerMove = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.velocity = Vector2.up * soPlayer.forceJump;
        }
    }
}
