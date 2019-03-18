using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAttackController : MonoBehaviour
{
    public float MaxBulletLifetime = 20f;
    public float FDamage = 1.0f;
    public float FStaminaDamage = 1.0f;
    private float currentBulletLifetime;

    private GameObject FAttack;
    private Rigidbody2D rb;
    private Vector3 movementDirection;
    private bool readyToUse = false;
    private HealthController playerHealthController;
    private StaminaController playerStaminaController;

    public Vector3 OrientationVector = new Vector3(0, 1, 0);

    public void SetMovementDirection(Vector3 movementDirection)
    {
        this.movementDirection = movementDirection;

        readyToUse = true;
    }

    void Start()
    {
        FAttack = gameObject;
        rb = GetComponent<Rigidbody2D>();

        currentBulletLifetime = MaxBulletLifetime;
        playerHealthController = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<HealthController>();
        playerStaminaController = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<StaminaController>();
    }

    void Update()
    {
        if (readyToUse)
        {
            FAttack.GetComponent<Rigidbody2D>().velocity = movementDirection;

            currentBulletLifetime -= Time.deltaTime;
            if (currentBulletLifetime <= 0)
            {
                Destroy(this.FAttack);
            }
        }
    }

    public void setDamage(float damage)
    {
        this.FDamage = damage;
    }

    public void setStaminaDamage(float damage)
    {
        this.FStaminaDamage = damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (readyToUse)
        {
            if (!other.CompareTag("Enemy") && !other.CompareTag("Vidal") && !other.CompareTag("Enemy Projectile") && !other.CompareTag("Bullet") && !other.CompareTag("Pickup"))
            {
                if (other.CompareTag("Player"))
                {
                    if (playerHealthController != null)
                    {
                        var playerHealth = playerHealthController.playerHit(FDamage);
                        if (playerHealth <= 0)
                        {
                            Destroy(other.gameObject);
                            Destroy(this.FAttack);
                            Application.Quit();
                        }
                    }
                    if (playerStaminaController != null)
                    {
                        playerStaminaController.playerHit(FStaminaDamage);
                    }
                }
                Destroy(this.FAttack);
            }
        }
    }
}
