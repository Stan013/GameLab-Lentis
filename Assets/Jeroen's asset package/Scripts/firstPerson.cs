using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class firstPerson : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject secondObject;
    public GameObject thirdObject;

    public string clickButton;
    public Transform hand;
    public GameObject Minigame;
    public GameObject GoodParticle;
    public GameObject badParticle;
    public Camera thisCam;
    public int selectedObj;
    public static bool IsLeft, IsRight, IsUp, IsDown;
    private float _LastX, _LastY;

    [SerializeField] private float FinalValue;
    [SerializeField] private GameObject selectedFood;
    private bool minigameIsPlaying;
    private void Start()
    {
      //  thisCam = gameObject.GetComponentInChildren<Camera>();
        thisCam.enabled = false;
        FinalValue = Minigame.GetComponentInChildren<MoveBar>().finalValue;
    }
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Selectable")
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
        }
    }
    private void Update()
    {
        FinalValue = Minigame.GetComponentInChildren<MoveBar>().finalValue;
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
        if(thisCam.enabled == true)
        {
            Selecting();
        }
        if(minigameIsPlaying == true)
        {
            if (Minigame.activeInHierarchy == false)
            {
                Instantiate(selectedFood, new Vector3(0, 0, 0), Quaternion.identity, hand);
                if(FinalValue >= 70)
                {
                    Instantiate(GoodParticle, selectedFood.transform);
                }
                else
                {
                    Instantiate(badParticle, selectedFood.transform);
                }
                thisCam.enabled = false;
                minigameIsPlaying = false;
            }

        }

    }

    void Selecting()
    {
        switch (selectedObj)
        {
            case 1:
                firstObject.GetComponent<Renderer>().material.color = Color.green;
                secondObject.GetComponent<Renderer>().material.color = Color.white;
                thirdObject.GetComponent<Renderer>().material.color = Color.white;
                if (Input.GetButtonDown(clickButton))
                {
                    Minigame.SetActive(true);
                    minigameIsPlaying = true;
                    selectedFood = firstObject;
                    if (hand.childCount > 0)
                    {
                        Destroy(hand.GetChild(0).gameObject);
                    }
                }
                break;
            case 2:
                firstObject.GetComponent<Renderer>().material.color = Color.white;
                secondObject.GetComponent<Renderer>().material.color = Color.green;
                thirdObject.GetComponent<Renderer>().material.color = Color.white;
                if (Input.GetButtonDown(clickButton))
                {
                    Minigame.SetActive(true);
                    minigameIsPlaying = true;
                    selectedFood = secondObject;
                    if(hand.childCount > 0)
                    {
                        Destroy(hand.GetChild(0).gameObject);
                    }
                }
                break;
            case 3:
                firstObject.GetComponent<Renderer>().material.color = Color.white;
                secondObject.GetComponent<Renderer>().material.color = Color.white;
                thirdObject.GetComponent<Renderer>().material.color = Color.green;
                if (Input.GetButtonDown(clickButton))
                {
                    Minigame.SetActive(true);
                    minigameIsPlaying = true;
                    selectedFood = thirdObject;
                    if (hand.childCount > 0)
                    {
                        Destroy(hand.GetChild(0).gameObject);
                    }
                }
                break;
        }
    }
}
