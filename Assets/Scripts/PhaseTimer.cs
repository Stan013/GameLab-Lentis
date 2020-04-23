using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseTimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float resetTime;
    public string phase;
    [SerializeField] private Text timerText;

    [SerializeField] private GuestAI guest1;
    [SerializeField] private GuestAI guest2;
    void Update ()
    {
        checkPhase();
        CoundownTimer();
    }

    void CoundownTimer()
    {
        time -= Time.deltaTime;
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        timerText.text = (minutes + ":" + seconds);
        if(time <= 0){
            if(phase == "Prep"){
                phase = "Work";
            }else{
                phase = "Prep";
            }
            time = resetTime;
        }
    }

    void checkPhase(){
        if(phase == "Work"){
            //Enable guests
            if(timerText.text == "03:00"){
                guest1.makeOrder("Drink1");
                guest2.makeOrder("Food1");
            }
        }
        if(phase == "Prep"){
            //Disable guests
        }
    }
}
