using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{

    public int WaveCount = 5;
    public int EnemiesPerWave = 10;
    public int TimeBetweenWaves = 20;

    private bool active = false;


    // Update is called once per frame
    void Update()
    {
        Debug.Log("Objective"+this.gameObject.transform.position);
    }
}
