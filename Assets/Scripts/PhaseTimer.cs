using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseTimer : MonoBehaviour
{
    [SerializeField] private float time = 180;
    [SerializeField] private string phase = "Prep";
    public Text timerText;
 
    void Update ()
    {
        CoundownTimer();
    }

    void CoundownTimer()
    {
        time -= Time.deltaTime;
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        timerText.text = (minutes + ":" + seconds);
        Debug.Log("Time Left: " + minutes + ":" + seconds);
        if(time <= 0)
        {
            if(phase == "Prep")
            {
                //Go to work phase
                phase = "Work";
            }else{
                //Go to prep phase
                phase = "Prep";
            }
            time = 180;
        }
    }
}
