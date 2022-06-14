using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    public Animator enemyAnimator;
    public string triggerAttack = "Attack";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthBase health = collision.gameObject.GetComponent<HealthBase>();

        if (health)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        enemyAnimator.SetTrigger(triggerAttack);
    }
}
