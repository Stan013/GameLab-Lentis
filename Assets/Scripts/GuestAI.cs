using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuestAI : MonoBehaviour
{
    [SerializeField] private Transform[] wayPointList;
    [SerializeField] private Transform[] tempArray;
    private int currentWayPoint = 0; 
    private int currentWayPoint2 = 0; 
    Transform targetWayPoint;
    Transform targetWayPoint2;
    [SerializeField] private float speed;
    [SerializeField] private PhaseTimer phase;
    private GameObject orderWanted;
    [SerializeField] private AudioClip pointSound;
    private AudioSource audioSrc;
    public bool musicOn = false;
    [SerializeField] private Animator animator;
    
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
        audioSrc = GetComponent <AudioSource>();
    }

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
                orderWanted = drink1;
            break;
            case "Drink2":
                drink2.SetActive(true);
                orderWanted = drink2;
            break;
            case "Drink3":
                drink3.SetActive(true);
                orderWanted = drink3;
            break;
            case "Food1":
                food1.SetActive(true);
                orderWanted = food1;
            break;
            case "Food2":
                food2.SetActive(true);
                orderWanted = food2;
            break;
            case "Food3":
                food3.SetActive(true);
                orderWanted = food3;
            break;
            case "Music":
                music.SetActive(true);
                orderWanted = music;
            break;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (Input.GetButton(collider.GetComponent<Movement>().activityButton))
            {
                if (orderWanted.name +("(Clone)") == collider.GetComponent<Movement>().OrderObject.name)
                {
                    if(!audioSrc.isPlaying)
                    {
                        if(pointSound != null)
                        {
                            audioSrc.PlayOneShot(pointSound);
                        }
                    }
                    collider.GetComponent<Movement>().PlayerScore += 1;
                    deleteOrder();
                    if(collider.GetComponent<firstPerson>().orderQuality == "Good")
                    {
                        collider.GetComponent<Movement>().PlayerScore += 1;
                    }
                    Destroy(collider.GetComponent<Movement>().OrderObject);
                }
                else
                {
                    if(musicOn == true)
                    {
                        if(!audioSrc.isPlaying)
                        {
                            if(pointSound != null)
                            {
                                audioSrc.PlayOneShot(pointSound);
                            }
                        }
                        collider.GetComponent<Movement>().PlayerScore += 1;
                        deleteOrder();
                        if (collider.GetComponent<firstPerson>().orderQuality == "Good")
                        {
                            collider.GetComponent<Movement>().PlayerScore += 1;
                        }
                    }else{
                        Debug.Log("Wrong order");
                    }
                }
            }
        }
    }
}
