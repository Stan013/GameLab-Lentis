using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableDisable : MonoBehaviour
{
    public GameObject canvasObj;
    public bool showBars;
    public Image[] images;
    public SpriteRenderer[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        showBars = false;
        images = canvasObj.GetComponentsInChildren<Image>();
        sprites = canvasObj.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Joystick1Button4))
        {
            showBars = true;
        }
        else 
        {
            showBars = false;
        }

        if (showBars == false)
        {
            foreach (Image imageID in images)
            {
                imageID.enabled = false;
            }
            foreach (SpriteRenderer spriteRD in sprites)
            {
                spriteRD.enabled = false;
            }
        }
        if (showBars == true)
        {
            foreach (Image imageID in images)
            {
                imageID.enabled = true;
            }
            foreach (SpriteRenderer spriteRD in sprites)
            {
                spriteRD.enabled = true;
            }
        }
    }
}
