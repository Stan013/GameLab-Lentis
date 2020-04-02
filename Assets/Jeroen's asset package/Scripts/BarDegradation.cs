using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarDegradation : MonoBehaviour
{
    public enum bars { Sadness, Happiness, Anxiety, Anger, Energy }
    public float minimum = -90;
    public float maximum = 90;
    public float barValue;
    public GameObject Pointer;
    public GameObject playerCharacter;
    public Transform rt;
    // Update is called once per frame
    void Start()
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
                Debug.Log("Anxiety");
                break;
            case "Anger":
                barValue = playerCharacter.GetComponent<Movement>().Anger;
                break;
            case "Energy":
                barValue = playerCharacter.GetComponent<Movement>().Energy;
                Debug.Log("Energy");
                break;
        }
        Debug.Log(barValue);
    }
    void Update()
    {
        Vector3 pos = new Vector3(barValue, rt.position.y, rt.position.z);
        if (barValue != minimum && barValue != maximum)
        {
            rt.position = pos;
        }
    }
}
