using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupController : MonoBehaviour
{
    public AudioSource pickupSound;
    public float HealthRegenValue = 5f;

    private void Start()
    {
        pickupSound = this.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pickupSound.transform.parent = null;
            pickupSound.Play();
            Destroy(pickupSound.gameObject, pickupSound.clip.length);
            GameObject player = other.gameObject;
            HealthController healthController = player.GetComponent<HealthController>();
            healthController.Heal(this.HealthRegenValue);
            Destroy(this.gameObject);
        }
    }

}
