using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    private float startingHealth;
    private float currentHealth;
    private float scaleHealth;
    private float startingBarX;
    private float startingBarY;
    void Start()
    {
        startingBarX = this.transform.localScale.x;
        startingBarY = this.transform.localScale.y;
        startingHealth = GetComponentInParent<Enemy1HealthController>().getHealth();
        currentHealth = startingHealth;
    }


    public void scale(float currentHealth)
    {
        if (startingHealth > 0)
        {
            scaleHealth = currentHealth / startingHealth;
            scaleHealth = startingBarX * scaleHealth;
        }
        else
        {
            scaleHealth = 1;
        }

        transform.localScale = new Vector3(scaleHealth, startingBarY, 1);
    }
}
