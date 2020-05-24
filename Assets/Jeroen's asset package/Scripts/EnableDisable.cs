using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnableDisable : MonoBehaviour
{
    public GameObject canvasObj;
    public bool showBars;
    public Image[] images;
    public SpriteRenderer[] sprites;
    public string activateButton;
    // Start is called before the first frame update

    void Start()
    {
        images = canvasObj.GetComponentsInChildren<Image>();
        sprites = canvasObj.GetComponentsInChildren<SpriteRenderer>();
       // showBars = false;
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Ending")
        {
            showBars = true;
            foreach (Image imageID in images)
            {
                imageID.enabled = true;
            }
            foreach (SpriteRenderer spriteRD in sprites)
            {
                spriteRD.enabled = true;
            }
            this.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            this.GetComponent<Canvas>().worldCamera = Camera.current;
            this.GetComponent<EnableDisable>().enabled = false;
        }
        else
        {
            if (Input.GetButton(activateButton))
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
}
