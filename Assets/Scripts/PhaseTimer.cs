using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseTimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float resetTime;
    public string phase;
    [SerializeField] private float phaseCount = 0;
    [SerializeField] private Text timerText;

    [SerializeField] private GuestAI guest1;
    [SerializeField] private GuestAI guest2;
    [SerializeField] private GuestAI guest3;
    [SerializeField] private GuestAI guest4;
    [SerializeField] private GuestAI guest5;
    [SerializeField] private GuestAI guest6;
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
                phaseCount++;
                switch(phaseCount){
                    case 1:
                        phase = "WorkIntro";
                    break;
                    case 2:
                        phase = "WorkWave1";
                    break;
                    case 3:
                        phase = "WorkWave2";
                    break;
                    case 4:
                        phase = "WorkWave3";
                    break;
                }
            }else{
                phase = "Prep";
            }
            time = resetTime;
        }
    }

    void checkPhase(){
        switch(phase){
            case "WorkIntro":
                if(timerText.text == "03:00"){
                    guest1.makeOrder("Drink1");
                }
                if(timerText.text == "02:15"){
                    guest2.makeOrder("Food1");
                }
                if(timerText.text == "01:30"){
                    guest1.makeOrder("Food2");
                }
                if(timerText.text == "00:45"){
                    guest2.makeOrder("Drink2");
                }
            break;
            case "WorkWave1":
                if(timerText.text == "03:00"){
                    guest1.makeOrder("Drink1");
                }
                if(timerText.text == "02:15"){
                    guest2.makeOrder("Food1");
                }
                if(timerText.text == "01:30"){
                    guest1.makeOrder("Food2");
                }
                if(timerText.text == "00:45"){
                    guest2.makeOrder("Drink2");
                }
            break;
        }
        if(phase == "Prep"){
            //Disable guests
        }
    }
}
