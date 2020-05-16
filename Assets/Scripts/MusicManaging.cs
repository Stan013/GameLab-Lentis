using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private Movement movement;
    private bool minigameIsPlaying = false;
    public string orderQuality;
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
                }
                else
                {
                    orderQuality = "Bad";
                }
                movement.enabled = true;
                minigameIsPlaying = false;
            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "RadioSet")
        {
            if(Input.GetButtonDown(activeMinigame))
            {
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
}
