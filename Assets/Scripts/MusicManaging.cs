using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManaging : MonoBehaviour
{
    public int Happiness;
    public int Sadness;
    public int Anger;
    public int Anxiety;
    public int Energy;

    public GameObject Minigame;
    public string activeMinigame;
    public float FinalValue;
    delegate void RandomizeEmotions();
    List<RandomizeEmotions> randomEmotion = new List<RandomizeEmotions>();
    private MoveBar Bar;

    public GameObject GoodParticle;
    public GameObject badParticle;

    public Image ButtonImg;

    [SerializeField] private Movement movement;
    private bool minigameIsPlaying = false;
    public string orderQuality;

    [SerializeField]private GameObject Clone;
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
        Bar = Minigame.GetComponentInChildren<MoveBar>();
        CreateList();
        movement = this.GetComponent<Movement>();
    }

    private void Update()
    {
        FinalValue = Minigame.GetComponentInChildren<MoveBar>().finalValue;

        if (minigameIsPlaying == true)
        {
            if (Minigame.activeInHierarchy == false )
            {
                movement.Happiness += Happiness;
                movement.Sadness += Sadness;
                movement.Anger += Anger;
                movement.Anxiety += Anxiety;
                movement.Energy += Energy;
                if (FinalValue >= 70)
                {
                    orderQuality = "Good";
                    GoodParticleSpawn();
                }
                else
                {
                    orderQuality = "Bad";
                    BadParticleSpawn();
                }
                movement.enabled = true;
                minigameIsPlaying = false;
            }

        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "RadioSet")
        {
            ButtonImg.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RadioSet")
        {
            ButtonImg.enabled = false;
        }
    }
        private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "RadioSet")
        {
            if(Input.GetButtonDown(activeMinigame))
            {
                Destroy(Clone.gameObject);
                minigameIsPlaying = true;
                Minigame.SetActive(true);
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

    void GoodParticleSpawn()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("RadioSet");
        foreach (GameObject target in gameObjects)
        {
            Clone = Instantiate(GoodParticle, target.transform);
        }
    }

    void BadParticleSpawn()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("RadioSet");
        foreach (GameObject target in gameObjects)
        {
            Clone = Instantiate(badParticle, target.transform);
        }
    }
}
