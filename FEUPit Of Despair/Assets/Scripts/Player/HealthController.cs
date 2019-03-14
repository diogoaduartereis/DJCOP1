using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float startingHealth;
    private float currentHealth;
    private bool invulnerable = false;

    public Slider healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthbar.value = CalculatedHealth();
    }

    public float playerHit(float damage)
    {
        if (!invulnerable)
        {
            currentHealth -= damage;
            healthbar.value = CalculatedHealth();
        }

        return currentHealth;
    }

    public void SetInvulnerable(bool status)
    {
        invulnerable = status;
    }

    float CalculatedHealth()
    {
        return currentHealth / startingHealth;
    }
}
