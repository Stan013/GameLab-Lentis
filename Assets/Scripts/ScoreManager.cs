using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public static int finalScore = 0;
    public static int Player1Score;
    public static int Player2Score;
    public static int Player3Score;
    public static int Player4Score;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        
    }
    // Update is called once per frame

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
            Player1Score = GameObject.Find("PlayerP1").GetComponent<Movement>().PlayerScore;
            Player2Score = GameObject.Find("PlayerP2").GetComponent<Movement>().PlayerScore;
            Player3Score = GameObject.Find("PlayerP3").GetComponent<Movement>().PlayerScore;
            Player4Score = GameObject.Find("PlayerP4").GetComponent<Movement>().PlayerScore;
            finalScore = Player1Score + Player2Score + Player3Score + Player4Score;
        }

        Debug.Log("Scenes: " + currentName + ", " + next.name);
    }
}
