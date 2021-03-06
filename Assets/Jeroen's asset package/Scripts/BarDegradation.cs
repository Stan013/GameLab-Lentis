﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarDegradation : MonoBehaviour
{
    public float minimum = -100;
    public float maximum = 100;
    public float barValue;
    public float pointerValue;
    public GameObject Pointer;
    public GameObject playerCharacter;
    public Transform rt;
    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        switch (gameObject.tag)
        {
            case "Sadness":
                barValue = playerCharacter.GetComponent<Movement>().Sadness;
                break;
            case "Happiness":
                barValue = playerCharacter.GetComponent<Movement>().Happiness;
                break;
            case "Anxiety":
                barValue = playerCharacter.GetComponent<Movement>().Anxiety;
                break;
            case "Anger":
                barValue = playerCharacter.GetComponent<Movement>().Anger;
                break;
            case "Energy":
                barValue = playerCharacter.GetComponent<Movement>().Energy;
                break;
        }
        if (barValue <= maximum && barValue >= minimum)
        {
            pointerValue = barValue * 0.9f;
            Vector3 temp = new Vector3(pointerValue, 14f, 0f);
            rt.transform.localPosition = temp;
        }
    }
}
