using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDoor : MonoBehaviour
{
    [SerializeField] private Animator animatorLift;

    void Start () {
        animatorLift.enabled = true;
        animatorLift.SetBool("Open2", false); //when you have animations in your game, there's a tab next to "Scene", "Game" and "Asset Store" named "Animator". There
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Guest" || collider.gameObject.tag == "Player"){
            if(animatorLift.GetBool("Open2") == false){
                animatorLift.SetBool("Open2", true);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Guest" || collider.gameObject.tag == "Player"){
            if(animatorLift.GetBool("Open2") == true){
                animatorLift.SetBool("Open2", false);
            }
        }
    }
}
