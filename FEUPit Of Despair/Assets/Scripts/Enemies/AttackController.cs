using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Vector3 ShootingOffset = new Vector3(0, 0.5f, 0);

    public float ShootingCooldown = 0.25f;
    private float CurrentShootingCooldown = 0;
    public float stoppingDistance;

    private GameObject Player;
    private Rigidbody2D rb;

    public GameObject fireball;
    public float fireballSpeed;

    private GameObject BulletHolder;
    private Transform target;
    private Vector3 direction;

    void Start()
    {
        BulletHolder = new GameObject("Fireball Holder");

        Player = gameObject;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (transform == null || target == null)
        {
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance)
        {
            if (CurrentShootingCooldown <= 0)
            {
                direction = (target.transform.position - transform.position).normalized * fireballSpeed;
                CurrentShootingCooldown = ShootingCooldown;
                GameObject fireballInst = Instantiate(fireball, transform.position, Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                fireballInst.GetComponentInChildren<FireBallController>().SetMovementDirection(direction);
               
                CurrentShootingCooldown = ShootingCooldown;
                fireballInst.transform.parent = BulletHolder.transform;
            }
        }
    }

    void Update()
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

    public void destroyHolder()
    {
        Destroy(this.BulletHolder);
    }
}
