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
    public GameObject panel;
    public string button;
    public Movement Emotions;
    public float finalValue;
    private void Update()
    {
        MoveSlider();

        RectTransform rt = this.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(30, height);


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
        if (Input.GetButton(button))
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
    }
    void Sadness()
    {

    }

    void Happiness()
    {

    }

    void Anxiety()
    {

    }

    void Anger()
    {

    }

    void Energy()
    {

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        panel.SetActive(false);
        finalValue = slider.value;
        slider.value = 15;
        yield return null;
    }
}