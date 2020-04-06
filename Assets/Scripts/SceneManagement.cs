using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void StartGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Controls()
    {
        if(transform.Find("MainPanel").gameObject.activeInHierarchy == true)
        {
            transform.Find("MainPanel").gameObject.SetActive(false);
            transform.Find("ControlPanel").gameObject.SetActive(true);
        }
        else
        {
            transform.Find("MainPanel").gameObject.SetActive(true);
            transform.Find("ControlPanel").gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Cancel") && transform.Find("MainPanel").gameObject.activeInHierarchy == false)
        {
            Controls();
        }
    }
}
