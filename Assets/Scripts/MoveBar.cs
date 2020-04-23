using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBar : MonoBehaviour
{
    public float speed = 0.2f;
    public float height = 50f;
    public Slider slider;
    private bool hittingOjbect;
    private void Update()
    {
        if (Input.GetButton("Jump"))
        {
            transform.localPosition += new Vector3(0, speed, 0f);
        }
        else
        {
            transform.localPosition += new Vector3(0, -speed, 0f);
        }
        var pos = transform.localPosition;
        pos.y = Mathf.Clamp(transform.localPosition.y, -73, 73f);
        transform.localPosition = pos;

        RectTransform rt = this.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(30, height);

        if(slider.value == slider.maxValue)
        {
            //Do Something
        }

        if(hittingOjbect == true)
        {
            slider.value += 0.5f;
        }
        else
        {
            slider.value -= 0.5f;
        }

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

}