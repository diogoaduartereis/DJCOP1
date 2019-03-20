using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FireBallController : MonoBehaviour
{
    public float MaxBulletLifetime = 20f;
    public float FireballDamage = 1.0f;
    private float currentBulletLifetime;

    private GameObject Fireball;
    private Rigidbody2D rb;
    private Vector3 movementDirection;
    private bool readyToUse = false;
    private HealthController playerHealthController;

    public Vector3 OrientationVector = new Vector3(0,1,0);

    public void SetMovementDirection(Vector3 movementDirection)
    {
        this.movementDirection = movementDirection;

        float rotationAngle = 180 - Vector3.Angle(this.movementDirection, this.OrientationVector);
        if (Fireball == null)
        {
            Fireball = gameObject;
        }

        var angle = transform.rotation.eulerAngles;
        if (movementDirection.x > 0)
        {
            angle.z = rotationAngle;
        }
        else
        {
            angle.z = -rotationAngle;
        }

        Fireball.transform.rotation = Quaternion.Euler(angle);

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

    public void setDamage(float damage)
    {
        this.FireballDamage = damage;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (readyToUse)
        {
            if (!other.CompareTag("Enemy") && !other.CompareTag("Vidal") && !other.CompareTag("Enemy Projectile") && !other.CompareTag("Bullet") && !other.CompareTag("Pickup"))
            {
                if (other.CompareTag("Player"))
                {
                    GameObject.FindGameObjectWithTag("PickupSound").GetComponents<AudioSource>()[2].Play();
                    if (playerHealthController != null)
                    {
                        var playerHealth = playerHealthController.playerHit(FireballDamage);
                        if (playerHealth <= 0)
                        {
                            Destroy(other.gameObject);
                            Destroy(this.Fireball);
                            SceneManager.LoadScene("GameOverMenu");
                        }
                        Destroy(this.Fireball);
                    }
                }
                Destroy(this.Fireball);
            }
        }
    }
    
}
