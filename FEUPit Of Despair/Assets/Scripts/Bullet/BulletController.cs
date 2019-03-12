using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
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
    }

    void Update()
    {
        if (readyToUse)
        {
            rb.MovePosition(Bullet.transform.position + movementDirection * BulletSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (readyToUse)
        {
            Debug.Log("Object Destroyed");
            Destroy(this.Bullet);
        }
    }
}
