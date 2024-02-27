using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int damageBullet = 1;
    



    public void SetTarget(Transform _target)
    {
        target = _target;
    }


    private void FixedUpdate()
    {
        if (!target) return;


        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Health>().TakeDamage(damageBullet);

        Destroy(gameObject);
    }


}
