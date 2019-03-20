using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    public float StartingTime = 20f;
    // Start is called before the first frame update
    void Start()
    {
        this.StartingTime *= 60;
        StartCoundownTimer();
    }

    void StartCoundownTimer()
    {
        if (timerText != null)
        {
            timerText.text = StartingTime + ":00";
        }
    }

    void Update()
    {
        if (timerText != null)
        {
            StartingTime -= Time.deltaTime;
            string minutes = Mathf.Floor(StartingTime / 60).ToString("00");
            string seconds = (StartingTime % 60).ToString("00");
            if (minutes == "00" && seconds == "00")
            {
                SceneManager.LoadScene("GameOverMenu");
            }
            timerText.text = minutes + ":" + seconds;
        }
    }
}
