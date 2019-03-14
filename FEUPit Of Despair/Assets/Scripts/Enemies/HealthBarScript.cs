using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    // Update is called once per frame
    public void scale(float currentHealth)
    {
        transform.localScale += new Vector3(-currentHealth, 0, 0);
    }
}
