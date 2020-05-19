using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platePickup : MonoBehaviour
{
    public GameObject platesSpawner;
    public Transform location;
    public int plateAmount;
    public GameObject platePrefab;

    void Update()
    {
        plateAmount = platesSpawner.GetComponent<platesSpawning>().amountofPlates;
        float distance = Vector3.Distance(gameObject.transform.position, platesSpawner.transform.position);
        if (plateAmount > 0)
        {
            Debug.Log("works");
            if (Input.GetKeyDown(KeyCode.Joystick1Button1) && distance <= 5f)
                {
                plateAmount -= 1;
                GameObject G = Instantiate(platePrefab, location.position, Quaternion.Euler(-90, 0, 0));
                G.transform.parent = location;
                G.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
