using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseGame : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject timerPanel;
    public void Pause()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
            timerPanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            PausePanel.SetActive(false);
            timerPanel.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause();
        }
    }
}
