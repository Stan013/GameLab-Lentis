using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public static int finalScore = 0;
    public int Player1Score;
    public int Player2Score;
    public int Player3Score;
    public int Player4Score;
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
        
    }
    // Update is called once per frame


}
