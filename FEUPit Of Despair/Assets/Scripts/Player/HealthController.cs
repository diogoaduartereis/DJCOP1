using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float startingHealth;
    private float currentHealth;
    private UIHealthTrigger healthTrigger;
    private bool invulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthTrigger = GameObject.FindGameObjectsWithTag("Health")[0].GetComponent<UIHealthTrigger>();
    }

    public float playerHit(float damage)
    {
        if (!invulnerable)
        {
            currentHealth -= damage;
            healthTrigger.changeImages((int) currentHealth);
        }

        return currentHealth;
    }

    public void SetInvulnerable(bool status)
    {
        invulnerable = status;
    }
}
