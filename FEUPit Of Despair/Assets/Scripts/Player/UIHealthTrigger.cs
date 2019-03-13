using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIHealthTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite HealthMax;
    public Sprite Health4;
    public Sprite Health3;
    public Sprite Health2;
    public Sprite HealthMin;
    public Sprite NoHealth;

    public void changeImages(int health)
    {
        switch (health)
        {
            case 5:
                GetComponent<Image>().sprite = HealthMax;
                break;
            case 4:
                GetComponent<Image>().sprite = Health4;
                break;
            case 3:
                GetComponent<Image>().sprite = Health3;
                break;
            case 2:
                GetComponent<Image>().sprite = Health2;
                break;
            case 1:
                GetComponent<Image>().sprite = HealthMin;
                break;
            case 0:
                GetComponent<Image>().sprite = NoHealth;
                break;

        }
    }
 
}
