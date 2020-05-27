using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoor : MonoBehaviour
{
    [SerializeField] private Animator animatorLift;

    void Start () {
        animatorLift.enabled = true;
        animatorLift.SetBool("Open", false);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Guest"){
            if(animatorLift.GetBool("Open") == false){
                animatorLift.SetBool("Open", true);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Guest"){
            if(animatorLift.GetBool("Open") == true){
                animatorLift.SetBool("Open", false);
            }
        }
    }
}
