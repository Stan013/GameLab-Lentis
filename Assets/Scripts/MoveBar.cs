using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBar : MonoBehaviour
{
    public float speed = 2f;
    public float upSpeed = 2f;
    public float downSpeed = 2f;
    public float height = 50f;
    public Slider slider;
    private bool hittingOjbect;
    public GameObject panel;
    public string button;
    public Movement Emotions;
    public float finalValue;

    public bool activityNotAvailable;
    public bool autoplay = false;

    public GameObject fakeFish;

    public float maxY = 4.2f;
    public float minY = -4.2f;

    private float tChange = 0; // force new direction in the first Update
    private float randomY;
    public float moveSpeed;

    private void Update()
    {

        MoveSlider();
        
        BoxCollider2D bc = this.GetComponent<BoxCollider2D>();
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(30, height);
        bc.size = new Vector2(30, height);
        


        if(hittingOjbect == true)
        {
            slider.value += 0.5f;
        }
        else
        {
            slider.value -= 0.5f;
        }
        StartCoroutine("Wait");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {
            hittingOjbect = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Fish")
        {
            hittingOjbect = false;
        }
    }
    void MoveSlider()
    {
        if (activityNotAvailable == false) 
        {
            if (Input.GetButton(button))
            {
                transform.localPosition += new Vector3(0, upSpeed, 0f);
            }
            else
            {
                transform.localPosition += new Vector3(0, -downSpeed, 0f);
            }
        }
        else if(autoplay == false)
        {
            transform.localPosition += new Vector3(0, -downSpeed, 0f);
        }
        
        
        var pos = transform.localPosition;
        pos.y = Mathf.Clamp(transform.localPosition.y, -73, 73f);
        transform.localPosition = pos;
    }
    public void Sadness()
    {
        if (Emotions.Sadness <= -60)
        {
            upSpeed = 0.2f;
            downSpeed = 0.2f;
        }
        else if(Emotions.Happiness <= 60 && Emotions.Sadness >= -60 && Emotions.Anger >= 60 && Emotions.Anger <=-60)
        {
            upSpeed = 2f;
            downSpeed = 2f;
        }

        if (Emotions.Sadness >= 60)
        {
            activityNotAvailable = true;
        }
        else if (Emotions.Happiness >= -60 && Emotions.Energy >= -60 && Emotions.Sadness <= 60)
        {
            activityNotAvailable = false;
        }
    }

    public void Happiness()
    {
        if(Emotions.Happiness >=60)
        {
            upSpeed = 5f;
            downSpeed = 5f;
        }
        else if (Emotions.Happiness <= 60 && Emotions.Sadness >= -60 && Emotions.Anger >= 60 && Emotions.Anger <= -60)
        {
            upSpeed = 2f;
            downSpeed = 2f;
        }

        if(Emotions.Happiness <= -60)
        {
            activityNotAvailable = true;
        }
        else if(Emotions.Happiness >= -60 && Emotions.Energy >= -60 && Emotions.Sadness <= 60)
        {
            activityNotAvailable = false;
        }
    }

    public void Anxiety()
    {
        if (Emotions.Anxiety >= 60)
        {
            height = 20f;
        }
        else
        {
            height = 50f;
        }

        if (Emotions.Anxiety <= -60)
        {
            fakeFish.SetActive(true);
        }
        else
        {
            fakeFish.SetActive(false);
        }
    }
    public void Anger()
    {
        if (Emotions.Anger >= 60)
        {
            upSpeed = 7f;
            downSpeed = 2f;
        }
        else if (Emotions.Happiness <= 60 && Emotions.Sadness >= -60 && Emotions.Anger <= 60)
        {
            upSpeed = 2f;
        }

        if (Emotions.Anger <= -60)
        {
            downSpeed = 5f;
            upSpeed = 2f;
        }
        else if (Emotions.Happiness <= 60 && Emotions.Sadness >= -60 && Emotions.Anger >=-60)
        {
            downSpeed = 2f;
        }
    }
    public void Energy()
    {
        if (Emotions.Energy >= 60)
        {
            //Bar moves on itself
            activityNotAvailable = true;
            autoplay = true;
            if (Time.time >= tChange)
            {
                randomY = Random.Range(-2, 2); //  between -2.0 and 2.0 is returned
                                               // set a random interval between 0.5 and 1.5
                tChange = Time.time + Random.Range(0.5f, 1.5f);
            }
            transform.Translate(new Vector2(0, randomY) * moveSpeed * Time.deltaTime);
            if (this.GetComponent<RectTransform>().localPosition.y >= maxY || this.GetComponent<RectTransform>().localPosition.y <= minY)
            {
                randomY = -randomY;
            }
            var pos = this.GetComponent<RectTransform>().localPosition;
            pos.y = Mathf.Clamp(this.GetComponent<RectTransform>().localPosition.y, minY, maxY);
            pos.z = this.GetComponent<RectTransform>().localPosition.z;
            this.GetComponent<RectTransform>().localPosition = pos;
        }
        else
        {
            autoplay = false;
        }

        if (Emotions.Energy <= -60)
        {
            activityNotAvailable = true;
        }
        else if (Emotions.Happiness >= -60 && Emotions.Energy >= -60 && Emotions.Energy <= 60 && Emotions.Sadness <= 60)
        {
            activityNotAvailable = false;
        }
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
        panel.SetActive(false);
        finalValue = slider.value;
        slider.value = 15;
        yield return null;
    }
}