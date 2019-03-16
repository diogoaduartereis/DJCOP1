using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public float startingStamina;
    private float currentStamina;
    public float regenRate;
    public float staminaPerRegen;
    private float timePassed;

    public Slider staminabar;

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = startingStamina;
        staminabar.value = CalculatedStamina();
    }

    public void playerDash(float staminaSpent)
    {
        currentStamina -= staminaSpent;
        staminabar.value = CalculatedStamina();
    }

    public void StaminaRegen()
    {
        staminabar.value = CalculatedStamina();
    }

    private float CalculatedStamina()
    {
        return currentStamina / startingStamina;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= regenRate)
        {
            if(this.currentStamina <= this.startingStamina)
            {
                if((this.currentStamina += staminaPerRegen) > this.startingStamina)
                {
                    this.currentStamina = this.startingStamina;
                    StaminaRegen();
                    timePassed = 0;
                }
                else
                {
                    StaminaRegen();
                    timePassed = 0;
                }
                timePassed = 0;
            }
            timePassed = 0;
        }
    }

    public float getStamina()
    {
        return currentStamina;
    }
}
