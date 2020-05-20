using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class firstPerson : MonoBehaviour
{
    public int Happiness;
    public int Sadness;
    public int Anger;
    public int Anxiety;
    public int Energy;

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

    public Image ButtonImg;
    public string selectButton;
    public string clickButton;
    public string activateFirstPerson;
    public Transform hand;
    public GameObject Minigame;
    public GameObject GoodParticle;
    public GameObject badParticle;
    public Camera thisCam;
    public int selectedObj;
    public Shader outlineShade;

    public static bool IsLeft, IsRight, IsUp, IsDown;
    private float _LastX, _LastY;
    private bool ActivityAvailable;
    [SerializeField] private float FinalValue;
    [SerializeField] private GameObject selectedFood;
    [SerializeField] private Movement movement;
    
    private bool minigameIsPlaying;
    public string orderQuality;

    public delegate void RandomizeEmotions();
    public List<RandomizeEmotions> randomEmotion = new List<RandomizeEmotions>();
    private MoveBar Bar;
    
    void CreateList()
    {
       
        randomEmotion.Add(Bar.Anger);
        randomEmotion.Add(Bar.Anxiety);
        randomEmotion.Add(Bar.Sadness);
        randomEmotion.Add(Bar.Happiness);
        randomEmotion.Add(Bar.Energy);
    }
    private void Start()
    {
      //  thisCam = gameObject.GetComponentInChildren<Camera>();
        thisCam.enabled = false;
        FinalValue = Minigame.GetComponentInChildren<MoveBar>().finalValue;
        movement = this.GetComponent<Movement>();
        Bar = Minigame.GetComponentInChildren<MoveBar>();
        CreateList();
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Selectable")
        {
            ButtonImg.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Selectable")
        {
            ButtonImg.enabled = false;
        }
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
                Anxiety = 20;
                Happiness = -10;
                Energy = -20;
            }
            else
            {
                Cakes.gameObject.SetActive(false);
                Drinks.gameObject.SetActive(true);
                firstObject = drink1;
                secondObject = drink2;
                thirdObject = drink3;
                Anger = 20;
                Happiness = -10;
                Energy = -10;
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
                    for (int i = 0; i < randomEmotion.Count; i++)
                    {
                        RandomizeEmotions temp = randomEmotion[i];
                        int randomIndex = Random.Range(i, randomEmotion.Count);
                        randomEmotion[i] = randomEmotion[randomIndex];
                        randomEmotion[randomIndex] = temp;
                        randomEmotion[i]();
                    }
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
            Debug.Log(selectedObj);
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
                movement.Happiness += Happiness;
                movement.Sadness += Sadness;
                movement.Anger += Anger;
                movement.Anxiety += Anxiety;
                movement.Energy += Energy;
                if (FinalValue >= 70)
                {
                    Instantiate(GoodParticle, Food.transform);
                    orderQuality = "Good";
                }
                else
                {
                    Instantiate(badParticle, Food.transform);
                    orderQuality = "Bad";
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
                firstObject.GetComponent<Renderer>().material.shader = outlineShade;
                secondObject.GetComponent<Renderer>().material.shader = null;
                thirdObject.GetComponent<Renderer>().material.shader = null;
                Debug.Log(firstObject.GetComponent<Renderer>().material);
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
                firstObject.GetComponent<Renderer>().material.shader = null;
                secondObject.GetComponent<Renderer>().material.shader = outlineShade;
                thirdObject.GetComponent<Renderer>().material.shader = null;
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
                firstObject.GetComponent<Renderer>().material.shader = null;
                secondObject.GetComponent<Renderer>().material.shader = null;
                thirdObject.GetComponent<Renderer>().material.shader = outlineShade;
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
