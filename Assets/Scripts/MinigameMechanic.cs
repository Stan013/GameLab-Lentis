using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameMechanic : MonoBehaviour
{
    public float maxY = 4.2f;
    public float minY = -4.2f;

    private float tChange = 0; // force new direction in the first Update
     private float randomY;
    public float moveSpeed;
     
     void Update()
    {
        // change to random direction at random intervals
        if (Time.time >= tChange)
        {
            randomY = Random.Range(-5, 5); //  between -2.0 and 2.0 is returned
                                               // set a random interval between 0.5 and 1.5
            tChange = Time.time + Random.Range(0.5f, 1.5f);
        }
        transform.Translate(new Vector2(0, randomY) * moveSpeed * Time.deltaTime);
        if (this.GetComponent<RectTransform>().localPosition.y >= maxY || this.GetComponent<RectTransform>().localPosition.y <= minY)
        {
            randomY = -randomY;
        }
        // make sure the position is inside the borders
        var pos = this.GetComponent<RectTransform>().localPosition;
        pos.y = Mathf.Clamp(this.GetComponent<RectTransform>().localPosition.y, minY, maxY);
        pos.z = this.GetComponent<RectTransform>().localPosition.z;
        this.GetComponent<RectTransform>().localPosition = pos;
    }
}
