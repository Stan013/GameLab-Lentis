using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platesSpawning : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    public GameObject platePrefab;
    public int amountofPlates = 0;
    public float timeAMt = 5;
    float time;
    public int maxPlayers = 1;
    public int amountOfPlayers = 0;
    public List<GameObject> targets = new List<GameObject>();
    public List<GameObject> plates = new List<GameObject>();
    public PhaseTimer phasemanager;

    public void Start()
    {
        StartCoroutine(spawnPlates());
    }
    public void Update()
    {
        //score removing script for plates at the end of phases goes here.
    }
    public void plateSpawner()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2 , size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        GameObject plate = Instantiate(platePrefab, pos, Quaternion.Euler(-90, 0, 0));
        plates.Add(plate);
    }
    public IEnumerator spawnPlates()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            if (amountofPlates < 5)
            {
                plateSpawner();
                amountofPlates += 1;
            }
            spawnPlates();
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && amountOfPlayers == maxPlayers)
        {

            if (Input.GetButton(other.GetComponent<Movement>().activityButton) && amountofPlates != 0)
            {
                if (this.gameObject.GetComponent<Animator>() != null && this.gameObject.GetComponent<Animator>().enabled == true)
                {
                    this.gameObject.GetComponent<Animator>().SetBool("Collision", true);
                }
                other.GetComponent<Movement>().button.enabled = false;
                if (time <= timeAMt)
                {
                    time += Time.deltaTime;
                    other.gameObject.GetComponent<Movement>().activitytimer.fillAmount = time / timeAMt;
                    Debug.Log(time);
                }
                if (time >= timeAMt)
                {
                    time = 0;

                    amountofPlates -= 1;
                    GameObject plateToRemove = plates[0];
                    plates.Remove(plateToRemove);
                    Destroy(plateToRemove);
                    ScoreManager.finalScore += 10;
                }
            }
            else
            {
                time = 0;
                other.GetComponent<Movement>().button.enabled = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            targets.Add(other.gameObject);
            other.GetComponent<Movement>().button.enabled = true;
            amountOfPlayers += 1;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            targets.Remove(other.gameObject);
            amountOfPlayers -= 1;
            time = 0;
            other.GetComponent<Movement>().activitytimer.fillAmount = time / timeAMt;
            other.GetComponent<Movement>().button.enabled = false;
            if (this.gameObject.GetComponent<Animator>() != null && this.gameObject.GetComponent<Animator>().enabled == true)
            {
                this.gameObject.GetComponent<Animator>().SetBool("Collision", false);
            }

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
