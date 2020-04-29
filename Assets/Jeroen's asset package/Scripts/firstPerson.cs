using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class firstPerson : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject secondObject;
    public GameObject thirdObject;
    private Camera thisCam;
    public int selectedObj;
    public static bool IsLeft, IsRight, IsUp, IsDown;
    private float _LastX, _LastY;

    private void Start()
    {
        thisCam = gameObject.GetComponentInChildren<Camera>();
        thisCam.enabled = false;
    }
    private void Update()
    {
        if (Input.GetButtonDown("activateFirstPerson"))
        {
            if (thisCam.isActiveAndEnabled)
            {
                thisCam.enabled = false;
            }
            else
            {
                thisCam.enabled = true;
            }
        }
        float x = Input.GetAxis("DPad X");


        IsLeft = false;
        IsRight = false;

        if (_LastX != x)
        {
            if (x == -1)
                IsLeft = true;
            else if (x == 1)
                IsRight = true;
        }
        _LastX = x;

        if (IsRight == true && selectedObj < 3)
        {
            selectedObj += 1;
        }
        if (IsLeft == true && selectedObj > 1)
        {
            selectedObj -= 1;
        }
        switch (selectedObj)
        {
            case 1:
                firstObject.GetComponent<Renderer>().material.color = Color.green;
                secondObject.GetComponent<Renderer>().material.color = Color.white;
                thirdObject.GetComponent<Renderer>().material.color = Color.white;
                break;
            case 2:
                firstObject.GetComponent<Renderer>().material.color = Color.white;
                secondObject.GetComponent<Renderer>().material.color = Color.green;
                thirdObject.GetComponent<Renderer>().material.color = Color.white;
                break;
            case 3:
                firstObject.GetComponent<Renderer>().material.color = Color.white;
                secondObject.GetComponent<Renderer>().material.color = Color.white;
                thirdObject.GetComponent<Renderer>().material.color = Color.green;
                break;
        }

    }
}
