using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidalHealthController : MonoBehaviour
{
    public float startingHealth;
    private float currentHealth;
    private float HP75;
    private float HP50;
    private float HP25;
    public GameObject Teachers;
    public GameObject Torcato;
    public GameObject ToFerreira;
    public GameObject Villate;
    public int amountOfEnemyTypesPerRound = 2;
    private int typeLength;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        HP75 = startingHealth - (startingHealth / 4);
        HP50 = startingHealth - 2*(startingHealth / 4);
        HP25 = startingHealth - 3*(startingHealth / 4);
        typeLength = amountOfEnemyTypesPerRound;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public float enemyHit(float damage)
    {
        currentHealth -= damage;
        this.GetComponentInChildren<VidalHealthbarScript>().scale(currentHealth);

        if(HP75 <= currentHealth + 0.3 && HP75 >= currentHealth - 0.3)
        {
            while(typeLength > 0)
            {
                GameObject TeachersInst = Instantiate(Teachers, (new Vector3(1, -1, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                GameObject TorcatoInst = Instantiate(Torcato, (new Vector3(2, -1, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                GameObject ToFerreiraInst = Instantiate(ToFerreira, (new Vector3(-1, -1, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                GameObject VillateFInst = Instantiate(Villate, (new Vector3(-2, -1, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                typeLength--;
            }
            typeLength = this.amountOfEnemyTypesPerRound;
        }
        else if (HP50 <= currentHealth + 0.3 && HP50 >= currentHealth - 0.3)
        {
            while (typeLength > 0)
            {
                GameObject TeachersInst = Instantiate(Teachers, (new Vector3(1, -1, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                GameObject TorcatoInst = Instantiate(Torcato, (new Vector3(2, -1, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                GameObject ToFerreiraInst = Instantiate(ToFerreira, (new Vector3(-1, -1, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                GameObject VillateFInst = Instantiate(Villate, (new Vector3(-2, -1, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
            }
            typeLength = this.amountOfEnemyTypesPerRound;
        }
        else if (HP25 <= currentHealth + 0.3 && HP25 >= currentHealth - 0.3)
        {
            while (typeLength > 0)
            {
                GameObject TeachersInst = Instantiate(Teachers, (new Vector3(1, -1, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                GameObject TorcatoInst = Instantiate(Torcato, (new Vector3(2, -1, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                GameObject ToFerreiraInst = Instantiate(ToFerreira, (new Vector3(-1, -1, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                GameObject VillateFInst = Instantiate(Villate, (new Vector3(-2, -1, 0) + transform.position), Quaternion.Euler(new Vector2(0, 0))) as GameObject;
                typeLength--;
            }
            typeLength = this.amountOfEnemyTypesPerRound;
        }
        return currentHealth;
    }

    public float getStartingHealth()
    {
        return startingHealth;
    }
}
