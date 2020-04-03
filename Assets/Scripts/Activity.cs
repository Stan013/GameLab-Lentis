using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activity : MonoBehaviour
{
    public Image filling;
    public Image button;
    public float timeAMt = 5;
    float time;
    public float addHappy;
    public float addAnger;
    public float addSad;
    public float addAnxiety;
    public float addEnergy;
    // public Text timeText;

    private void Update()
    {
        //  filling = this.GetComponent<Image>();
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "PlayerP1" && Input.GetButton("Fire1P1") || other.gameObject.name == "PlayerP2" && Input.GetButton("Fire1P2"))
        {
            button.enabled = false;
            if (time <= timeAMt)
            {
                time += Time.deltaTime;
                filling.fillAmount = time / timeAMt;
                Debug.Log(time);
            }
            if(time >= timeAMt)
            {
                time = 0;
                other.gameObject.GetComponent<Movement>().Happiness+= addHappy;
                other.gameObject.GetComponent<Movement>().Anger += addAnger;
                other.gameObject.GetComponent<Movement>().Anxiety+= addAnxiety;
                other.gameObject.GetComponent<Movement>().Sadness += addSad;
                other.gameObject.GetComponent<Movement>().Energy += addEnergy;
            }
        }
        else
        {
            time = 0;
            filling.fillAmount = time / timeAMt;
            button.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            button.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            time = 0;
            filling.fillAmount = time / timeAMt;
            button.enabled = false;
        }
    }
}
