using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarDegradation : MonoBehaviour
{
    public float minimum = -75;
    public float maximum = 75;
    public float barValue = 0;
    public bool goingUp = false;
    public bool goingDown = false;
    public bool stressIncreasing = false;
    public bool stressDecreasing = false;
    public GameObject Pointer;
    // Update is called once per frame
    void Start()
    {
        goingUp = true;    
    }
    void Update()
    {
        if (goingUp == true && barValue != maximum && stressIncreasing == false)
        {
            StartCoroutine("increaseStress");
        }
        else if (goingDown == true && barValue != minimum && stressDecreasing == false)
        {
            StartCoroutine("decreaseStress");
        }
    }
    IEnumerator increaseStress()
    {
        stressIncreasing = true;
        barValue += 1;
        Pointer.transform.Translate(0.41f, -0, -0);
        yield return new WaitForSeconds(0.1f);
        if (barValue == maximum)
        {
            StopCoroutine("increaseStress");
            stressIncreasing = false;
        }
        else
        {
            StartCoroutine("increaseStress");
        }
    }
    IEnumerator decreaseStress()
    {
        stressDecreasing = true;
        barValue -= 1;
        Pointer.transform.Translate(-0.41f, -0, -0);
        yield return new WaitForSeconds(0.1f);
        if (barValue == minimum)
        {
            StopCoroutine("decreaseStress");
            stressDecreasing = false;
        }
        else
        {
            StartCoroutine("decreaseStress");
        }
    }
}
