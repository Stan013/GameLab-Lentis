using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public GameObject playerCharacter;
    public Sprite[] happySprites;
    public Sprite[] sadSprites;
    public Sprite[] anxSprites;
    public Sprite[] angrySprites;
    public Sprite[] energySprites;
    public SpriteRenderer happySprite;
    public SpriteRenderer sadSprite;
    public SpriteRenderer anxiousSprite;
    public SpriteRenderer angrySprite;
    public SpriteRenderer energySprite;

    public int happiness;
    public int sadness;
    public int anxiety;
    public int anger;
    public int energy;

    void Update()
    {
        happiness = playerCharacter.GetComponent<Movement>().Happiness;
        sadness = playerCharacter.GetComponent<Movement>().Sadness;
        anxiety = playerCharacter.GetComponent<Movement>().Anxiety;
        anger = playerCharacter.GetComponent<Movement>().Anger;
        energy = playerCharacter.GetComponent<Movement>().Energy;

        if (happiness > -20 && happiness < 20)
        {
            happySprite.sprite = happySprites[0];
        }
        if (happiness <= -20 && happiness > -60 || happiness >= 20 && happiness < 60)
        {
            happySprite.sprite = happySprites[1];
        }
        if (happiness <= -60 || happiness >= 60)
        {
            happySprite.sprite = happySprites[2];
        }
        if (sadness > -20 && sadness < 20)
        {
            sadSprite.sprite = sadSprites[0];
        }
        if (sadness <= -20 && sadness > -60 || sadness >= 20 && sadness < 60)
        {
            sadSprite.sprite = sadSprites[1];
        }
        if (sadness <= -60 || sadness >= 60)
        {
            sadSprite.sprite = sadSprites[2];
        }
        if (anxiety > -20 && anxiety < 20)
        {
            anxiousSprite.sprite = anxSprites[0];
        }
        if (anxiety <= -20 && anxiety > -60 || anxiety >= 20 && anxiety < 60)
        {
            anxiousSprite.sprite = anxSprites[1];
        }
        if (anxiety <= -60 || anxiety >= 60)
        {
            anxiousSprite.sprite = anxSprites[2];
        }
        if (anger > -20 && anger < 20)
        {
            angrySprite.sprite = angrySprites[0];
        }
        if (anger <= -20 && anger > -60 || anger >= 20 && anger < 60)
        {
            angrySprite.sprite = angrySprites[1];
        }
        if (anger <= -60 || anger >= 60)
        {
            angrySprite.sprite = angrySprites[2];
        }
        if (energy > -20 && energy < 20)
        {
            energySprite.sprite = energySprites[0];
        }
        if (energy <= -20 && energy > -60 || energy >= 20 && energy < 60)
        {
            energySprite.sprite = energySprites[1];
        }
        if (energy <= -60 || energy >= 60)
        {
            energySprite.sprite = energySprites[2];
        }


    }
}
