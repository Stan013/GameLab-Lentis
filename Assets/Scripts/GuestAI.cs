using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuestAI : MonoBehaviour
{
    [SerializeField] private Transform[] wayPointList;
    private int currentWayPoint = 0; 
    Transform targetWayPoint;
    [SerializeField] private float speed;
    [SerializeField] private PhaseTimer phase;
    
    private GameObject drink1;
    private GameObject drink2;
    private GameObject drink3;
    private GameObject food1;
    private GameObject food2;
    private GameObject food3;
    private GameObject bubble;
    private GameObject music;

    void Start(){
        bubble = GameObject.Find("Order/bubble");
        bubble.SetActive(false);
        drink1 = GameObject.Find("Order/coke bottle");
        drink1.SetActive(false);
        drink2 = GameObject.Find("Order/fristi");
        drink2.SetActive(false);
        drink3 = GameObject.Find("Order/applejuice");
        drink3.SetActive(false);
        food1 = GameObject.Find("Order/cake");
        food1.SetActive(false);
        food2 = GameObject.Find("Order/chocCake");
        food2.SetActive(false);
        food3 = GameObject.Find("Order/strawberrycake");
        food3.SetActive(false);
        music = GameObject.Find("Order/speakers");
        music.SetActive(false);
    }

    void Update () {
        if(phase.phase != "Prep"){
            if(currentWayPoint < wayPointList.Length){
                if(targetWayPoint == null){
                    targetWayPoint = wayPointList[currentWayPoint];
                }
                Move();
            }
        }
    }
 
    void Move(){
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, 6f*Time.deltaTime, 0.0f);
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
        if(transform.position == targetWayPoint.position)
        {
            currentWayPoint ++;
            targetWayPoint = wayPointList[currentWayPoint];
        }  
    } 

    public void deleteOrder()
    {
        bubble.SetActive(false);
        drink1.SetActive(false);
        drink2.SetActive(false);
        drink3.SetActive(false);
        food1.SetActive(false);
        food2.SetActive(false);
        food3.SetActive(false);
        music.SetActive(false);
    }

    public void makeOrder(string order){
        bubble.SetActive(true);
        switch(order){
            case "Drink1":
                drink1.SetActive(true);
            break;
            case "Drink2":
                drink2.SetActive(true);
            break;
            case "Drink3":
                drink3.SetActive(true);
            break;
            case "Food1":
                food1.SetActive(true);
            break;
            case "Food2":
                food2.SetActive(true);
            break;
            case "Food3":
                food3.SetActive(true);
            break;
            case "Music":
                music.SetActive(true);
            break;
        }
    }

    // void OnTriggerEnter(Collider collider)
    // {
    //     if(Input.GetButton(collider.GetComponent<Movement>().activityButton))
    //     {
    //         switch(collider.){
    //             case "coke bottle":

    //             break;
    //             case "fristi":

    //             break;
    //             case "applejuice":

    //             break;
    //             case "strawberrycake":

    //             break;
    //             case "chocCake":

    //             break;
    //             case "cake":

    //             break;
    //         }
    //     }
    // }
}
