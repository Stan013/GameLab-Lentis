using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseTimer : MonoBehaviour
{
    [SerializeField] private float time = 180;
    [SerializeField] private string phase = "Prep";
 
    void Update ()
    {
        CoundownTimer();
    }

    void CoundownTimer()
    {
        time -= Time.deltaTime;
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");

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
