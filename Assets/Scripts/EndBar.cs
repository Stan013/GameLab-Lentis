using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBar : MonoBehaviour
{
    public float minimum = -100;
    public float maximum = 100;
    public float barValue;
    public float pointerValue;
    public GameObject Pointer;
    public Transform rt;
    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        if (transform.gameObject.layer == LayerMask.NameToLayer("UIP1"))
        {
            switch (gameObject.tag)
            {
                case "Sadness":
                    barValue = ScoreManager.Player1Sadness;
                    break;
                case "Happiness":
                    barValue = ScoreManager.Player1Happiness;
                    break;
                case "Anxiety":
                    barValue = ScoreManager.Player1Anxiety;
                    break;
                case "Anger":
                    barValue = ScoreManager.Player1Anger;
                    break;
                case "Energy":
                    barValue = ScoreManager.Player1Energy;
                    break;
            }
        }

        if (transform.gameObject.layer == LayerMask.NameToLayer("UIP2"))
        {
            switch (gameObject.tag)
            {
                case "Sadness":
                    barValue = ScoreManager.Player2Sadness;
                    break;
                case "Happiness":
                    barValue = ScoreManager.Player2Happiness;
                    break;
                case "Anxiety":
                    barValue = ScoreManager.Player2Anxiety;
                    break;
                case "Anger":
                    barValue = ScoreManager.Player2Anger;
                    break;
                case "Energy":
                    barValue = ScoreManager.Player2Energy;
                    break;
            }
        }

        if (transform.gameObject.layer == LayerMask.NameToLayer("UIP3"))
        {
            switch (gameObject.tag)
            {
                case "Sadness":
                    barValue = ScoreManager.Player3Sadness;
                    break;
                case "Happiness":
                    barValue = ScoreManager.Player3Happiness;
                    break;
                case "Anxiety":
                    barValue = ScoreManager.Player3Anxiety;
                    break;
                case "Anger":
                    barValue = ScoreManager.Player3Anger;
                    break;
                case "Energy":
                    barValue = ScoreManager.Player3Energy;
                    break;
            }
        }

        if (transform.gameObject.layer == LayerMask.NameToLayer("UIP4"))
        {
            switch (gameObject.tag)
            {
                case "Sadness":
                    barValue = ScoreManager.Player4Sadness;
                    break;
                case "Happiness":
                    barValue = ScoreManager.Player4Happiness;
                    break;
                case "Anxiety":
                    barValue = ScoreManager.Player4Anxiety;
                    break;
                case "Anger":
                    barValue = ScoreManager.Player4Anger;
                    break;
                case "Energy":
                    barValue = ScoreManager.Player4Energy;
                    break;
            }
        }
        if (barValue <= maximum && barValue >= minimum)
        {
            pointerValue = barValue * 0.9f;
            Vector3 temp = new Vector3(pointerValue, 14f, 0f);
            rt.transform.localPosition = temp;
        }
    }
}
