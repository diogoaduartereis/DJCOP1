using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepNoteController : MonoBehaviour
{
    public float MaxBulletLifetime = 20f;
    public float FreezeLength = 2.0f;
    private float currentBulletLifetime;

    private GameObject SleepNote;
    private Rigidbody2D rb;
    private Vector3 movementDirection;
    private bool readyToUse = false;
    private GameObject player;

    public Vector3 OrientationVector = new Vector3(0, 1, 0);

    public void SetMovementDirection(Vector3 movementDirection)
    {
        this.movementDirection = movementDirection;
        
        if (SleepNote == null)
        {
            SleepNote = gameObject;
        }
        

        readyToUse = true;
    }

    void Start()
    {
        SleepNote = gameObject;
        rb = GetComponent<Rigidbody2D>();

        currentBulletLifetime = MaxBulletLifetime;
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    void Update()
    {
        if (readyToUse)
        {
            SleepNote.GetComponent<Rigidbody2D>().velocity = movementDirection;

            currentBulletLifetime -= Time.deltaTime;
            if (currentBulletLifetime <= 0)
            {
                Destroy(this.SleepNote);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (readyToUse)
        {
            if (!other.CompareTag("Enemy") && !other.CompareTag("Vidal") && !other.CompareTag("Enemy Projectile") && !other.CompareTag("Bullet") && !other.CompareTag("Pickup"))
            {
                if (other.CompareTag("Player"))
                {
                    if (player != null)
                    {
                        player.GetComponent<MovementController>().FreezePlayer(this.FreezeLength);
                        Destroy(this.SleepNote);
                    }
                }
                Destroy(this.SleepNote);
            }
        }
    }
}
