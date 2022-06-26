using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayer : ScriptableObject
{
    [Header("Speed setup")]
    public Vector2 friction = new Vector2(-0.3f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 20f;


    [Header("Animation setup")]
    public float jumpScale = 1.1f;
    public float animationDuration = 0.3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public float playerSwipeDuration = 0.05f;
}
