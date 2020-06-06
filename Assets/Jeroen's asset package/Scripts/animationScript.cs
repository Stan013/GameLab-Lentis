using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour
{
    [SerializeField] public GameObject playerChar;
    [SerializeField] private Animator animController;
    [SerializeField] private GameObject radioBox1;
    [SerializeField] private GameObject soccerBall;
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
        if (Input.GetButton(this.GetComponent<Movement>().activityButton) && (this.GetComponent<Movement>().button.isActiveAndEnabled) && (Vector3.Distance(playerChar.transform.position, soccerBall.transform.position) < 1))
        {
            Debug.Log(Vector3.Distance(playerChar.transform.position, soccerBall.transform.position));
            animController.SetBool("isKicking", true);

        } else 
        {
            animController.SetBool("isKicking", false);
        }
        if (Input.GetButton(this.GetComponent<Movement>().activityButton) && (this.GetComponent<Movement>().button.isActiveAndEnabled) && (Vector3.Distance(playerChar.transform.position, radioBox1.transform.position) < 2))
        {
            animController.SetBool("isDancing", true);
        } else
        {
            animController.SetBool("isDancing", false);
        }
    }
}
