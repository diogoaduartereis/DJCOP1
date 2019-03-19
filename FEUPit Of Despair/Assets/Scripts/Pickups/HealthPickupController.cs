using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupController : MonoBehaviour
{
    public GameObject pickupSound;
    public float HealthRegenValue = 5f;

    private void Start()
    {
        pickupSound = GameObject.FindGameObjectsWithTag("PickupSound")[0];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            HealthController healthController = player.GetComponent<HealthController>();
            healthController.Heal(this.HealthRegenValue);
            pickupSound.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }

}
