using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase projectileBase;

    public Transform shootPosition;
    public float timeBetweenShoot = 0.3f;

    public Transform playerSideRef;

    private Coroutine _currentCoroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(projectileBase);
        projectile.transform.position = shootPosition.position;
        projectile.side = playerSideRef.transform.localScale.x;
    }
}
