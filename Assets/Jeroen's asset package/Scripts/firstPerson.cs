using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class firstPerson : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject secondObject;
    public GameObject thirdObject;

    public GameObject Cakes;
    public GameObject Drinks;
    public GameObject drink1;
    public GameObject drink2;
    public GameObject drink3;
    public GameObject food1;
    public GameObject food2;
    public GameObject food3;

    public string selectButton;
    public string clickButton;
    public string activateFirstPerson;
    public Transform hand;
    public GameObject Minigame;
    public GameObject GoodParticle;
    public GameObject badParticle;
    public Camera thisCam;
    public int selectedObj;
    public static bool IsLeft, IsRight, IsUp, IsDown;
    private float _LastX, _LastY;
    private bool ActivityAvailable;
    [SerializeField] private float FinalValue;
    [SerializeField] private GameObject selectedFood;
    [SerializeField] private Movement movement;
    private bool minigameIsPlaying;
    private void Start()
    {
      //  thisCam = gameObject.GetComponentInChildren<Camera>();
        thisCam.enabled = false;
        FinalValue = Minigame.GetComponentInChildren<MoveBar>().finalValue;
        movement = this.GetComponent<Movement>();
    }
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Selectable")
        {
            if(collision.gameObject.name == "Cakes")
            {
                Cakes.gameObject.SetActive(true);
                Drinks.gameObject.SetActive(false);
                firstObject = food1;
                secondObject = food2;
                thirdObject = food3;
            }
            else
            {
                Cakes.gameObject.SetActive(false);
                Drinks.gameObject.SetActive(true);
                firstObject = drink1;
                secondObject = drink2;
                thirdObject = drink3;
            }
            if (Input.GetButtonDown(activateFirstPerson))
            {
                if (thisCam.isActiveAndEnabled)
                {
                    thisCam.enabled = false;
                    movement.enabled = true;
                }
                else
                {
                    thisCam.enabled = true;
                    movement.enabled = false;
                }
            }
        }
    }
    private void Update()
    {
        FinalValue = Minigame.GetComponentInChildren<MoveBar>().finalValue;
        float x = Input.GetAxis(selectButton);


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
            if (Minigame.activeInHierarchy == false && hand.childCount == 0)
            {
                GameObject Food = Instantiate(selectedFood, new Vector3(0, 0, 0), Quaternion.identity, hand);
                Food.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
                Food.transform.localPosition = new Vector3(0, 0, 0);
                if(FinalValue >= 70)
                {
                    Instantiate(GoodParticle, Food.transform);
                }
                else
                {
                    Instantiate(badParticle, Food.transform);
                }
                thisCam.enabled = false;
                movement.enabled = true;
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
