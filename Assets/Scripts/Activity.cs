using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Activity : MonoBehaviour
{
    public int maxPlayers =1;
    public int amountOfPlayers =0;
    public List<GameObject> targets = new List<GameObject>();
    public float timeAMt = 5;
    float time;
    public int addHappy;
    public int addAnger;
    public int addSad;
    public int addAnxiety;
    public int addEnergy;
    [SerializeField] private AudioClip activitySound;
    [SerializeField] private AudioClip progressSound;
    [SerializeField] private AudioClip pointSound;
    private AudioSource audioSrc;
    public bool interacting = false;
    public Text text;

    void Start()
    {
        audioSrc = GetComponent <AudioSource>();
        text = GetComponentInChildren<Text>();
        text.enabled = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && amountOfPlayers == maxPlayers)
        {
           
            if(Input.GetButton(other.GetComponent<Movement>().activityButton))
            {
                interacting = true;
                if (this.gameObject.GetComponent<Animator>() != null && this.gameObject.GetComponent<Animator>().enabled == true)
                {
                    this.gameObject.GetComponent<Animator>().SetBool("Collision", true);
                }
                other.GetComponent<Movement>().button.enabled = false;
                if (time <= timeAMt)
                {
                    if (!audioSrc.isPlaying)
                    {
                        if (progressSound != null)
                        {
                            audioSrc.PlayOneShot(progressSound);
                        }
                        if (activitySound != null)
                        {
                            audioSrc.PlayOneShot(activitySound);
                        }
                    }
                    time += Time.deltaTime;
                    other.gameObject.GetComponent<Movement>().activitytimer.fillAmount = time / timeAMt;
                    Debug.Log(time);
                }
                if (time >= timeAMt)
                {
                    time = 0;
                    if (!audioSrc.isPlaying)
                    {
                        if (pointSound != null)
                        {
                            audioSrc.PlayOneShot(pointSound);
                        }
                    }
                    foreach (Movement stats in targets.Select(t => t.GetComponent<Movement>()))
                    {
                        stats.Happiness += addHappy;
                        stats.Anger += addAnger;
                        stats.Anxiety += addAnxiety;
                        stats.Sadness += addSad;
                        stats.Energy += addEnergy;

                        if (addHappy > 0)
                        {
                            stats.plusHappy.Play();
                        }
                        if (addHappy < 0)
                        {
                            stats.minusHappy.Play();
                        }
                        if (addAnxiety >= 0)
                        {
                            stats.plusAnxiety.Play();
                        }
                        if (addAnxiety < 0)
                        {
                            stats.minusAnxiety.Play();
                        }
                        if (addAnger >= 0)
                        {
                            stats.plusAnger.Play();
                        }
                        if (addAnger < 0)
                        {
                            stats.minusAnger.Play();
                        }
                        if (addSad >= 0)
                        {
                            stats.plusSadness.Play();
                        }
                        if (addSad < 0)
                        {
                            stats.minusSadness.Play();
                        }
                        if (addEnergy >= 0)
                        {
                            stats.plusEnergy.Play();
                        }
                        if (addEnergy< 0)
                        {
                            stats.minusEnergy.Play();
                        }

                    }
                }
            }
            else
            {
                time = 0;
                other.GetComponent<Movement>().button.enabled = true;
                audioSrc.Stop();
                interacting = false;
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            targets.Add(other.gameObject);
            other.GetComponent<Movement>().button.enabled = true;
            amountOfPlayers += 1;
            text.enabled = true;
            text.text =(amountOfPlayers + "/" + maxPlayers);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            targets.Remove(other.gameObject);
            amountOfPlayers -= 1;
            text.enabled = false;
            text.text = (amountOfPlayers + "/" + maxPlayers);
            time = 0;
            other.GetComponent<Movement>().activitytimer.fillAmount = time / timeAMt;
            other.GetComponent<Movement>().button.enabled = false;
            if (this.gameObject.GetComponent<Animator>() != null && this.gameObject.GetComponent<Animator>().enabled == true)
            {
               this.gameObject.GetComponent<Animator>().SetBool("Collision", false);
            }
           
        }
    }
}
