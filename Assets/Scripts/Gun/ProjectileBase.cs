using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;

    public float timeToReset = 2f;

    public float side = 1;

    public int damageAmount = 1;

    private void Awake()
    {
        Invoke(nameof(EndUsage), timeToReset);
    }

    private void Update()
    {
        transform.Translate(side * Time.deltaTime * direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if (enemy != null)
        {
            enemy.Damage(damageAmount);
            Destroy(gameObject);
        }
    }

    private void EndUsage()
    {
        gameObject.SetActive(false);
    }
}
