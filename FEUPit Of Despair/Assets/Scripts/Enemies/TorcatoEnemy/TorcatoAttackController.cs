using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorcatoAttackController : MonoBehaviour
{
    public Vector3 ShootingOffset = new Vector3(0, 0.5f, 0);

    public float ShootingCooldown = 0.25f;
    private float CurrentShootingCooldown = 0;
    public float stoppingDistance;

    private GameObject Player;
    private Rigidbody2D rb;

    public GameObject SleepNote;
    public float SleepNoteSpeed;

    private GameObject BulletHolder;
    private Transform target;
    private Vector3 direction;

    public Sprite IdleFace;
    public Sprite AttackFace;
    private float SpriteTime;

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
                direction = (target.transform.position - transform.position).normalized * SleepNoteSpeed;
                CurrentShootingCooldown = ShootingCooldown;
                GameObject SleepNoteSpeedInst = Instantiate(SleepNote, transform.position, Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                SleepNoteSpeedInst.GetComponentInChildren<SleepNoteController>().SetMovementDirection(direction);
                this.GetComponent<SpriteRenderer>().sprite = AttackFace;
                SpriteTime = 1f;

                CurrentShootingCooldown = ShootingCooldown;
                SleepNoteSpeedInst.transform.parent = BulletHolder.transform;
            }
        }
    }

    void Update()
    {
        if( SpriteTime > 0)
        {
            SpriteTime -= Time.deltaTime;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = IdleFace;
        }

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
