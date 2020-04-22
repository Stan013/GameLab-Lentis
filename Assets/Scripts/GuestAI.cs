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
    [SerializeField] private bool wantOrder = false;
    [SerializeField] private Canvas canvasOrder;

    [SerializeField] private Sprite spriteDrink1;
    [SerializeField] private Sprite spriteFood1;

    void Start(){
        canvasOrder.enabled = false;
    }

    void Update () {
        if(currentWayPoint < wayPointList.Length)
        {
            if(targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            Move();
        }
        checkOrder();
    }
 
    void Move(){
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, 6f*Time.deltaTime, 0.0f);
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
        if(transform.position == targetWayPoint.position)
        {
            currentWayPoint ++ ;
            targetWayPoint = wayPointList[currentWayPoint];
        }  
    } 

    void checkOrder(){
        if(wantOrder == true){
            canvasOrder.enabled = true;
        }
    }

    public void makeOrder(string order){
        wantOrder = true;
        switch(order){
            case "Drink1":
                canvasOrder.GetComponentInChildren<Image>().sprite = spriteDrink1;
            break;
            case "Drink2":

            break;
            case "Food1":
                canvasOrder.GetComponentInChildren<Image>().sprite = spriteFood1;
            break;
            case "Food2":

            break;
        }
    }
}
