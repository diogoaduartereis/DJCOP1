using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    private Animator anim;
    private Vector3 direction;
    public Rigidbody2D fireball;
    public float ShootingCooldown;
    private float CurrentShootingCooldown = 0;
    public Vector3 ShootingOffset = new Vector3(-0.5f, 0, 0);
    public GameObject healthPickup;

    private Transform target;

    public delegate void DeathDelegate();

    private DeathDelegate callback = null;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > 0.6)
        {
            direction = (target.transform.position - transform.position).normalized;

            anim.SetBool("EnemyMoving", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
            if (direction.x > 0)
                anim.SetFloat("MoveX", 1);
            if (direction.x < 0)
                anim.SetFloat("MoveX", -1);
        }
        else
        {
            anim.SetBool("EnemyMoving", false);
        }
           
    }

    private void Update()
    {
        if (CurrentShootingCooldown > 0)
        {
            CurrentShootingCooldown -= Time.deltaTime;
        }
        else
        {
            CurrentShootingCooldown = 0;
        }
    }

    public void Death()
    {
        callback?.Invoke();
        Instantiate(healthPickup, transform.position, healthPickup.transform.rotation); //your dropped sword
        Destroy(this.gameObject);
    }

    public void registerDeathCallback(DeathDelegate callback)
    {
        this.callback = callback;
    }
}
