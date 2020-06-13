using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhaseTimer : MonoBehaviour
{
    [SerializeField] private float time;
    private float resetTime = 210;
    public string phase;
    [SerializeField] private float phaseCount = 0;
    [SerializeField] private Text timerText;

    [SerializeField] private GameObject guest1;
    [SerializeField] private GameObject guest2;
    [SerializeField] private GameObject guest3;
    [SerializeField] private GameObject guest4;
    [SerializeField] private GameObject guest5;
    [SerializeField] private GameObject guest6;
    [SerializeField] private GameObject guest7;
    [SerializeField] private GameObject guest8;
    [SerializeField] private GameObject guest9;
    [SerializeField] private GameObject guest10;

    [SerializeField] private AudioClip orderSound;
    [SerializeField] private AudioClip phaseSound;
    private AudioSource audioSrc;

    void Start()
    {
        guest1.SetActive(false);
        guest2.SetActive(false);
        guest3.SetActive(false);
        guest4.SetActive(false);
        guest5.SetActive(false);
        guest6.SetActive(false);
        guest7.SetActive(false);
        guest8.SetActive(false);
        guest9.SetActive(false);
        guest10.SetActive(false);
        audioSrc = GetComponent <AudioSource>();
    }

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
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(phaseSound);
            }
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
        if(phase == "Prep" && phaseCount == 5){
            SceneManager.LoadScene("Ending");
        }
        if(phase == "Prep" && timerText.text == "03:00"){
            guest1.SetActive(false);
            guest2.SetActive(false);
            guest3.SetActive(false);
            guest4.SetActive(false);
            guest5.SetActive(false);
            guest6.SetActive(false);
            guest7.SetActive(false);
            guest8.SetActive(false);
            guest9.SetActive(false);
            guest10.SetActive(false);
        }
    }

    void checkPhase(){
        switch(phase){
            case "WorkIntro":
                guest1.SetActive(true);
                guest9.SetActive(true);
                guest10.SetActive(true);
                StartCoroutine(delayActive(guest2, 2));
                if(timerText.text == "03:00"){
                    guest1.GetComponent<GuestAI>().makeOrder("Drink1");
                    if(!audioSrc.isPlaying)
                    {
                        audioSrc.PlayOneShot(orderSound);
                    }
                }
                if(timerText.text == "02:15"){
                    guest2.GetComponent<GuestAI>().makeOrder("Food1");
                    if(!audioSrc.isPlaying)
                    {
                        audioSrc.PlayOneShot(orderSound);
                    }
                }
                if(timerText.text == "01:30"){
                    guest1.GetComponent<GuestAI>().deleteOrder();
                    guest1.GetComponent<GuestAI>().makeOrder("Food2");
                    if(!audioSrc.isPlaying)
                    {
                        audioSrc.PlayOneShot(orderSound);
                    }
                }
                if(timerText.text == "00:45"){
                    guest2.GetComponent<GuestAI>().deleteOrder();
                    guest2.GetComponent<GuestAI>().makeOrder("Drink2");
                    if(!audioSrc.isPlaying)
                    {
                        audioSrc.PlayOneShot(orderSound);
                    }
                }
                if(timerText.text == "00:00"){
                    guest1.GetComponent<GuestAI>().deleteOrder();
                    guest2.GetComponent<GuestAI>().deleteOrder();
                }
            break;
            case "WorkWave1":
                MakeWave1();
            break;
            case "WorkWave2":
                MakeWave2();
            break;
            case "WorkWave3":
                MakeWave3();
            break;
        }   
    }

    IEnumerator delayActive(GameObject guest, float time){
        yield return new WaitForSeconds(time);
        guest.SetActive(true);
    }

    void MakeWave1()
    {
        guest1.SetActive(true);
        guest9.SetActive(true);
        guest10.SetActive(true);
        StartCoroutine(delayActive(guest2, 2));
        StartCoroutine(delayActive(guest3, 4));
        StartCoroutine(delayActive(guest4, 6));
        if(timerText.text == "03:00"){
            guest1.GetComponent<GuestAI>().makeOrder("Drink1");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "02:30"){
            guest2.GetComponent<GuestAI>().makeOrder("Food1");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "02:00"){
            guest1.GetComponent<GuestAI>().deleteOrder();
            guest3.GetComponent<GuestAI>().makeOrder("Drink2");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "01:30"){
            guest2.GetComponent<GuestAI>().deleteOrder();
            guest4.GetComponent<GuestAI>().makeOrder("Food2");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "01:00"){
            guest3.GetComponent<GuestAI>().deleteOrder();
            guest1.GetComponent<GuestAI>().makeOrder("Food3");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "00:45"){
            guest2.GetComponent<GuestAI>().makeOrder("Drink3");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "00:30"){
            guest4.GetComponent<GuestAI>().deleteOrder();
        }
        if(timerText.text == "00:00"){
            guest1.GetComponent<GuestAI>().deleteOrder();
            guest2.GetComponent<GuestAI>().deleteOrder();
        }
    }

    void MakeWave2()
    {
        guest1.SetActive(true);
        guest9.SetActive(true);
        guest10.SetActive(true);
        StartCoroutine(delayActive(guest2, 2));
        StartCoroutine(delayActive(guest3, 4));
        StartCoroutine(delayActive(guest4, 6));
        StartCoroutine(delayActive(guest5, 8));
        StartCoroutine(delayActive(guest6, 10));
        if(timerText.text == "03:00"){
            guest1.GetComponent<GuestAI>().makeOrder("Drink3");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "02:40"){
            guest2.GetComponent<GuestAI>().makeOrder("Food3");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "02:20"){
            guest1.GetComponent<GuestAI>().deleteOrder();
            guest3.GetComponent<GuestAI>().makeOrder("Drink1");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "02:00"){
            guest2.GetComponent<GuestAI>().deleteOrder();
            guest4.GetComponent<GuestAI>().makeOrder("Food1");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "01:40"){
            guest3.GetComponent<GuestAI>().deleteOrder();
            guest5.GetComponent<GuestAI>().makeOrder("Music");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "01:20"){
            guest4.GetComponent<GuestAI>().deleteOrder();
            guest6.GetComponent<GuestAI>().makeOrder("Drink2");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "01:00"){
            guest5.GetComponent<GuestAI>().deleteOrder();
            guest3.GetComponent<GuestAI>().makeOrder("Food2");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "00:40"){
            guest6.GetComponent<GuestAI>().deleteOrder();
            guest4.GetComponent<GuestAI>().makeOrder("Food1");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "00:30"){
            guest1.GetComponent<GuestAI>().makeOrder("Drink1");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "00:20"){
            guest3.GetComponent<GuestAI>().deleteOrder();
        }
        if(timerText.text == "00:00"){
            guest4.GetComponent<GuestAI>().deleteOrder();
            guest4.GetComponent<GuestAI>().deleteOrder();
        }
    }

    void MakeWave3()
    {
        guest1.SetActive(true);
        guest9.SetActive(true);
        guest10.SetActive(true);
        StartCoroutine(delayActive(guest2, 2));
        StartCoroutine(delayActive(guest3, 4));
        StartCoroutine(delayActive(guest4, 6));
        StartCoroutine(delayActive(guest5, 8));
        StartCoroutine(delayActive(guest6, 10));
        StartCoroutine(delayActive(guest7, 12));
        StartCoroutine(delayActive(guest8, 14));
        if(timerText.text == "03:00"){
            guest1.GetComponent<GuestAI>().makeOrder("Drink3");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "02:45"){
            guest2.GetComponent<GuestAI>().makeOrder("Food3");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "02:30"){
            guest1.GetComponent<GuestAI>().deleteOrder();
            guest3.GetComponent<GuestAI>().makeOrder("Drink1");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "02:15"){
            guest2.GetComponent<GuestAI>().deleteOrder();
            guest4.GetComponent<GuestAI>().makeOrder("Food1");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "02:00"){
            guest3.GetComponent<GuestAI>().deleteOrder();
            guest5.GetComponent<GuestAI>().makeOrder("Music");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "01:45"){
            guest4.GetComponent<GuestAI>().deleteOrder();
            guest6.GetComponent<GuestAI>().makeOrder("Drink2");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "01:30"){
            guest5.GetComponent<GuestAI>().deleteOrder();
            guest7.GetComponent<GuestAI>().makeOrder("Food2");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "01:15"){
            guest6.GetComponent<GuestAI>().deleteOrder();
            guest8.GetComponent<GuestAI>().makeOrder("Food1");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "01:00"){
            guest7.GetComponent<GuestAI>().deleteOrder();
            guest1.GetComponent<GuestAI>().makeOrder("Drink1");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "00:45"){
            guest8.GetComponent<GuestAI>().deleteOrder();
            guest4.GetComponent<GuestAI>().makeOrder("Drink3");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "00:30"){
            guest1.GetComponent<GuestAI>().deleteOrder();
            guest5.GetComponent<GuestAI>().makeOrder("Music");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "00:25"){
            guest8.GetComponent<GuestAI>().makeOrder("Food3");
            if(!audioSrc.isPlaying)
            {
                audioSrc.PlayOneShot(orderSound);
            }
        }
        if(timerText.text == "00:15"){
            guest4.GetComponent<GuestAI>().deleteOrder();
        }
        if(timerText.text == "00:00"){
            guest5.GetComponent<GuestAI>().deleteOrder();
            guest8.GetComponent<GuestAI>().deleteOrder();
        }   
        phaseCount = 5;
    }
}
