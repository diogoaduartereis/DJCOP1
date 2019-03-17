using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    public float StartingTime = 20f;
    private float Seconds;
    private float FinalSeconds;
    // Start is called before the first frame update
    void Start()
    {
        FinalSeconds = 59;
        Seconds = 59;
        this.StartingTime *= 60;
        StartCoundownTimer();
    }

    void StartCoundownTimer()
    {
        if (timerText != null)
        {
            timerText.text = StartingTime + ":00";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    void Update()
    {
        if (timerText != null)
        {
            StartingTime -= Time.deltaTime;
            string minutes = Mathf.Floor(StartingTime / 60).ToString("00");
            string seconds = (StartingTime % 60).ToString("00");
            timerText.text = minutes + ":" + seconds;
        }
    }
}
