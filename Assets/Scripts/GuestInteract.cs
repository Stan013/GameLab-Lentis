using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestInteract : MonoBehaviour
{
    [SerializeField] private Transform[] wayPointList;
    [SerializeField] private Transform[] tempArray;
    private int currentWayPoint = 0; 
    private int currentWayPoint2 = 0; 
    Transform targetWayPoint;
    Transform targetWayPoint2;
    [SerializeField] private float speed;
    [SerializeField] private PhaseTimer phase;
    [SerializeField] private Animator animator;
    
    void Update () {
        if(phase.phase != "Prep"){
            Move();
        }else{
            MoveBack();
        }
    }
 
    void Move(){
        if(currentWayPoint == wayPointList.Length){
            animator.SetBool("Move", false);
        }else{
            animator.SetBool("Move", true);
        }
        if(currentWayPoint < tempArray.Length){
            if(targetWayPoint == null){
                targetWayPoint = wayPointList[currentWayPoint];
            }
            transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, 6.0f*Time.deltaTime, 0.0f);
            transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
            if(transform.position == targetWayPoint.position){
                currentWayPoint ++;
                if(currentWayPoint < wayPointList.Length){
                    targetWayPoint = wayPointList[currentWayPoint];
                }
            }
        }
        currentWayPoint2 = 0;
        targetWayPoint2 = null;
    } 

    void MoveBack(){
        animator.SetBool("Move", true);
        if(currentWayPoint2 < tempArray.Length){
            if(targetWayPoint2 == null){
                targetWayPoint2 = tempArray[currentWayPoint2];
            }
            transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint2.position - transform.position, 6.0f*Time.deltaTime, 0.0f);
            transform.position = Vector3.MoveTowards(transform.position, targetWayPoint2.position, speed*Time.deltaTime);
            if(transform.position == targetWayPoint2.position){
                currentWayPoint2 ++;
                if(currentWayPoint2 < tempArray.Length){
                    targetWayPoint2 = tempArray[currentWayPoint2];
                }
            }
        }
        currentWayPoint = 0;
        targetWayPoint = null;
    }
}
