using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidalAttackController : MonoBehaviour
{
    public Vector3 ShootingOffset = new Vector3(0, 0.5f, 0);

    public float ShootingCooldown = 0.25f;
    private float CurrentShootingCooldown = 0;
    public float stoppingDistance;

    private GameObject Player;
    private Rigidbody2D rb;

    public GameObject fireball;
    public float fireballSpeed;

    public GameObject basketBall;
    public float basketBallSpeed;

    public GameObject FAttack;
    public float FAttackSpeed;

    public GameObject SleepNote;
    public float SleepNoteSpeed;

    private GameObject BulletHolder;
    private Transform target;
    private Vector3 directionFireBall;
    private Vector3 directionSleepNote;
    private Vector3 directionBasketball;
    private Vector3 directionF;

    public float fireballDamage;
    public float basketballDamage;
    public float FDamage;
    public float FStaminaDamage;

    void Start()
    {
        BulletHolder = new GameObject("Fireball Holder");

        Player = gameObject;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if(fireballDamage <= 0)
        {
            this.fireballDamage = 1;
        }

        if (basketballDamage <= 0)
        {
            this.basketballDamage = 1;
        }

        if (FDamage <= 0)
        {
            this.FDamage = 1;
        }

        if (FStaminaDamage <= 0)
        {
            this.FStaminaDamage = 1;
        }

    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance)
        {
            if (CurrentShootingCooldown <= 0)
            {
                directionFireBall = (target.transform.position - transform.position).normalized * fireballSpeed;
                directionSleepNote = (target.transform.position - transform.position - new Vector3(1,0,0)).normalized * SleepNoteSpeed;
                directionBasketball = (target.transform.position - transform.position + new Vector3(1, 0, 0)).normalized * basketBallSpeed;
                directionF = (target.transform.position - transform.position + new Vector3(2, 0, 0)).normalized * FAttackSpeed;

                CurrentShootingCooldown = ShootingCooldown;
                GameObject fireballInst = Instantiate(fireball, (new Vector3(ShootingOffset.x, ShootingOffset.y, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                GameObject SleepNoteInst = Instantiate(SleepNote, (new Vector3(ShootingOffset.x, ShootingOffset.y, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                GameObject BasketballInst = Instantiate(basketBall, (new Vector3(ShootingOffset.x, ShootingOffset.y, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                GameObject FInst = Instantiate(FAttack, (new Vector3(ShootingOffset.x, ShootingOffset.y, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;

                //fireball 
                fireballInst.GetComponentInChildren<FireBallController>().setDamage(this.fireballDamage);
                fireballInst.GetComponentInChildren<FireBallController>().SetMovementDirection(directionFireBall);

                //basketball
                BasketballInst.GetComponentInChildren<FireBallController>().setDamage(this.basketballDamage);
                BasketballInst.GetComponentInChildren<FireBallController>().SetMovementDirection(directionBasketball);

                //F attack
                FInst.GetComponentInChildren<FAttackController>().setDamage(this.FDamage);
                FInst.GetComponentInChildren<FAttackController>().setStaminaDamage(this.FStaminaDamage);
                FInst.GetComponentInChildren<FAttackController>().SetMovementDirection(directionF);

                //sleepnote
                SleepNoteInst.GetComponentInChildren<SleepNoteController>().SetMovementDirection(directionSleepNote);

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
}
