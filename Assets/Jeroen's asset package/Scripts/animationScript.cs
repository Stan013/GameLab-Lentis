using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour
{
    public GameObject playerChar;
    [SerializeField] private Animator animController;
    [SerializeField] private GameObject radioBox1;
    [SerializeField] private GameObject soccerBall;
    [SerializeField] private Movement player;
    [SerializeField] private Camera firstPersonMode;

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
        if (Input.GetButton(this.GetComponent<Movement>().activityButton) && (Vector3.Distance(playerChar.transform.position, soccerBall.transform.position) < 10)) //&& (soccerBall.GetComponent<Activity>().amountOfPlayers == 2)
        {
            if (soccerBall.GetComponentInParent<Activity>().interacting == true)
            {
                if (GlobalsManager.Instance.goalKeep == true)
                {
                    animController.SetBool("isKicking", true);
                    GlobalsManager.Instance.goalKeep = false;
                    playerChar.transform.position = new Vector3(-5.324f, playerChar.transform.position.y, 8.2f);
                    playerChar.transform.rotation = new Quaternion(playerChar.transform.rotation.x, 180f, playerChar.transform.rotation.z, playerChar.transform.rotation.w);
                }
                else
                {
                    GlobalsManager.Instance.goalKeep = true;
                    animController.SetBool("isBlocking", true);
                    playerChar.transform.position = new Vector3(-5.324f, playerChar.transform.position.y, 5.2f);
                    playerChar.transform.rotation = new Quaternion(playerChar.transform.rotation.x, 0f, playerChar.transform.rotation.z, playerChar.transform.rotation.w);
                    int blockChance = Random.Range(0, 2);
                    if (blockChance == 0)
                    {
                        animController.SetBool("blockSuccess", true);
                    }
                    else if (blockChance == 1)
                    {
                        animController.SetBool("blockSuccess", false);
                    }
                }


            }
        }
        else
        {
            animController.SetBool("isKicking", false);
            animController.SetBool("isBlocking", false);
            GlobalsManager.Instance.goalKeep = false;
        }
        
        if (Input.GetButton(this.GetComponent<Movement>().activityButton) && (Vector3.Distance(playerChar.transform.position, radioBox1.transform.position) < 5) && (radioBox1.GetComponent<Activity>().interacting == true)) 
        {
            animController.SetBool("isDancing", true);
        } else
        {
            animController.SetBool("isDancing", false);
        }

    }
}
