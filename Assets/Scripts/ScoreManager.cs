using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static int finalScore;
    public static int Player1Score;
    public static int Player2Score;
    public static int Player3Score;
    public static int Player4Score;
    // Start is called before the first frame update
    private static ScoreManager playerInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "Scene Gradus")
        {
            Player1Score = GameObject.Find("PlayerP1").GetComponent<Movement>().PlayerScore;
            Player2Score = GameObject.Find("PlayerP2").GetComponent<Movement>().PlayerScore;
            Player3Score = GameObject.Find("PlayerP3").GetComponent<Movement>().PlayerScore;
            Player4Score = GameObject.Find("PlayerP4").GetComponent<Movement>().PlayerScore;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Ending");
        }

        finalScore = Player1Score + Player2Score + Player3Score + Player4Score;
    }
}
