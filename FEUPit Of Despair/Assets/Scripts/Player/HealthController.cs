using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int startingHealth;
    private int currentHealth;
    private UIHealthTrigger healthTrigger;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthTrigger = GameObject.FindGameObjectsWithTag("Health")[0].GetComponent<UIHealthTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int playerHit()
    {
        currentHealth--;
        healthTrigger.changeImages(currentHealth);
        return currentHealth;
    }
}
