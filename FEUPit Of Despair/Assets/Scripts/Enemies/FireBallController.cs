using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public float MaxBulletLifetime = 20f;
    private float currentBulletLifetime;

    public float FireBallSpeed = 2.0f;
    private GameObject Fireball;
    private Rigidbody2D rb;
    private Vector3 movementDirection;
    private bool readyToUse = false;
    private HealthController playerHealthController;
    public void SetMovementDirection(Vector3 movementDirection)
    {
        this.movementDirection = movementDirection;
        readyToUse = true;
    }

    void Start()
    {
        Fireball = gameObject;
        rb = GetComponent<Rigidbody2D>();

        currentBulletLifetime = MaxBulletLifetime;
        playerHealthController = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<HealthController>();
    }

    void Update()
    {
        if (readyToUse)
        {
            Fireball.GetComponent<Rigidbody2D>().velocity = movementDirection;

            currentBulletLifetime -= Time.deltaTime;
            if (currentBulletLifetime <= 0)
            {
                Destroy(this.Fireball);
            }
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (readyToUse)
        {
            if (!other.CompareTag("Enemy") && !other.CompareTag("Fireball"))
            {
                if (other.CompareTag("Player"))
                {
                    var playerHealth = playerHealthController.playerHit();
                    if(playerHealth <= 0)
                    {
                        Destroy(other.gameObject);
                        Destroy(this.Fireball);
                        Application.Quit();
                    }
                }
                Destroy(this.Fireball);
            }
        }
    }
    
}
