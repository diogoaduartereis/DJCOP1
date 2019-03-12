using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float MaxBulletLifetime = 20f;
    private float currentBulletLifetime;

    public float BulletSpeed = 1.0f;
    private GameObject Bullet;
    private Rigidbody2D rb;
    private Vector3 movementDirection;
    private bool readyToUse = false;
    public void SetMovementDirection(Vector3 movementDirection)
    {
        this.movementDirection = movementDirection;
        readyToUse = true;
    }

    void Start()
    {
        Bullet = gameObject;
        rb = GetComponent<Rigidbody2D>();

        currentBulletLifetime = MaxBulletLifetime;
    }

    void Update()
    {
        if (readyToUse)
        {
            rb.MovePosition(Bullet.transform.position + movementDirection * BulletSpeed * Time.deltaTime);

            currentBulletLifetime -= Time.deltaTime;
            if (currentBulletLifetime <= 0)
            {
                Destroy(this.Bullet);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (readyToUse)
        {
            if (!other.CompareTag("Player") && !other.CompareTag("Bullet"))
            {
                if (other.CompareTag("Enemy"))
                {
                    Destroy(other.gameObject);
                }
                Destroy(this.Bullet);
            }
        }
    }
}
