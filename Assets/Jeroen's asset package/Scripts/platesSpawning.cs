using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platesSpawning : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    public GameObject platePrefab;
    public int amountofPlates = 0;
    public void Start()
    {
        StartCoroutine(spawnPlates());
    }
    public void plateSpawner()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2 , size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(platePrefab, pos, Quaternion.Euler(-90, 0, 0));
    }
    public IEnumerator spawnPlates()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            plateSpawner();
            amountofPlates += 1;
            spawnPlates();
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
