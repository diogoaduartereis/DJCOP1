using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public float startingHealth;
    private float currentHealth;
    private bool invulnerable = false;
    private float staminaCost = 0;

    public Slider healthbar;

    private StaminaController StaminaController;
    private MovementController movementController;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthbar.value = CalculatedHealth();

        this.StaminaController = GetComponent<StaminaController>();
        this.movementController = GetComponent<MovementController>();
    }

    public float playerHit(float damage)
    {
        if (!invulnerable)
        {
            currentHealth -= damage;
            healthbar.value = CalculatedHealth();
        }
        else
        {
            this.StaminaController.playerDefend(this.staminaCost);
            if (this.StaminaController.getStamina() < this.staminaCost)
            {
                this.movementController.SetNotGuarding();
            }
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOverMenu");
        }

        return currentHealth;
    }

    public void SetInvulnerable(bool status, float staminaCost)
    {
        invulnerable = status;
        this.staminaCost = staminaCost;
    }

    float CalculatedHealth()
    {
        return currentHealth / startingHealth;
    }

    public void Heal(float HealAmmount)
    {
        this.currentHealth += HealAmmount;
        if (this.currentHealth > this.startingHealth)
        {
            this.currentHealth = this.startingHealth;
        }

        healthbar.value = CalculatedHealth();
    }
}
