using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour
{
    [SerializeField] public GameObject playerChar;
    [SerializeField] private Animator animController;
    [SerializeField] private BoxCollider danceCollider;
    [SerializeField] private Movement player;
    [SerializeField] private Camera firstPersonMode;

    [SerializeField] public bool isKeeper = false;
    [SerializeField] public bool isKicking = false;
    [SerializeField] public bool isDancing = false;
    [SerializeField] public bool pointScored = false;

    // Update is called once per frame
    void Update()
    {
        if (player.Sadness < -60)
        {
            animController.SetBool("isSad", true);
        }
        else
        {
            animController.SetBool("isSad", false);
        }

        if (player.Anger > 60)
        {
            animController.SetBool("isAngry", true);
        }
        else
        {
            animController.SetBool("isAngry", false);
        }
        if (firstPersonMode.isActiveAndEnabled)
        {
            animController.SetBool("isBaking", true);
        } else
        {
            animController.SetBool("isBaking", false);
        }
        if (danceCollider.bounds.Contains(playerChar.transform.position))
        {
            isDancing = true;
            Debug.Log("dancing");
        }
        if (danceCollider.bounds.Contains(this.gameObject.transform.position) && Input.GetButton(gameObject.GetComponent<Movement>().activityButton)) 
        {
            animController.SetBool("isDancing", true);
            Debug.Log("dancing");
        }
    }
}
