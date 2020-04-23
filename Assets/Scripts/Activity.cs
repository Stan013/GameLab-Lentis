using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activity : MonoBehaviour
{
    public float timeAMt = 5;
    float time;
    public float addHappy;
    public float addAnger;
    public float addSad;
    public float addAnxiety;
    public float addEnergy;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetButton(other.GetComponent<Movement>().activityButton))
        {
            if(this.gameObject.GetComponent<Animator>().enabled == true)
            {
                this.gameObject.GetComponent<Animator>().SetBool("Collision", true);
            }
            other.GetComponent<Movement>().button.enabled = false;
            if (time <= timeAMt)
            {
                time += Time.deltaTime;
                other.gameObject.GetComponent<Movement>().activitytimer.fillAmount = time / timeAMt;
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
            other.gameObject.GetComponent<Movement>().activitytimer.fillAmount = time / timeAMt;
            other.GetComponent<Movement>().button.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Movement>().button.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            time = 0;
            other.GetComponent<Movement>().activitytimer.fillAmount = time / timeAMt;
            other.GetComponent<Movement>().button.enabled = false;
            this.gameObject.GetComponent<Animator>().SetBool("Collision", false);
        }
    }
}
