using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveController : MonoBehaviour
{

    public int WaveCount = 5;
    public int EnemiesPerWave = 10;
    public int TimeBetweenWaves = 20;

    private bool active = true;


    private int remainingEnemies;

    public GameObject[] SpawnableEnemies;

    void Start()
    {
        remainingEnemies = EnemiesPerWave;
    }

    // Update is called once per frame
    public void DeathCallback()
    {
        Interlocked.Decrement(ref remainingEnemies);
        if (remainingEnemies <= 0)
        {
            active = false;
            SceneManager.LoadScene("BossScene",LoadSceneMode.Single);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (active)
        {
            if (other.CompareTag("Player"))
            {
                for (int i = 0; i < EnemiesPerWave; ++i)
                {
                    IntRange range = new IntRange(0,SpawnableEnemies.Length);
                    GameObject mob =
                        Instantiate(SpawnableEnemies[range.Random], transform.position, Quaternion.identity) as GameObject;
                    mob.GetComponent<SimpleEnemy>().registerDeathCallback(DeathCallback);
                }
            }
        }
    }
}
