using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    void OnTriggerLeave(Collider collider){
        collider.gameObject.SetActive(false);
    }
}
