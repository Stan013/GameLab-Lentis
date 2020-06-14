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

    public static int Player1Happiness;
    public static int Player1Sadness;
    public static int Player1Anger;
    public static int Player1Anxiety;
    public static int Player1Energy;

    public static int Player2Happiness;
    public static int Player2Sadness;
    public static int Player2Anger;
    public static int Player2Anxiety;
    public static int Player2Energy;

    public static int Player3Happiness;
    public static int Player3Sadness;
    public static int Player3Anger;
    public static int Player3Anxiety;
    public static int Player3Energy;

    public static int Player4Happiness;
    public static int Player4Sadness;
    public static int Player4Anger;
    public static int Player4Anxiety;
    public static int Player4Energy;
    // Start is called before the first frame update
    private static ScoreManager playerInstance;

    [SerializeField] private PhaseTimer phase;
    public Text scoreText;
    public Text phaseText;
    private string text;
    
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(playerInstance.gameObject);
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
        if(phase.phase != "Prep")
        {
            phaseText.text = ("Guests are here");
        }else{
            phaseText.text = ("Look at your emotions");
        }

        if (sceneName == "Scene Gradus")
        {
            Player1Score = GameObject.Find("PlayerP1").GetComponent<Movement>().PlayerScore;
            Player2Score = GameObject.Find("PlayerP2").GetComponent<Movement>().PlayerScore;
            Player3Score = GameObject.Find("PlayerP3").GetComponent<Movement>().PlayerScore;
            Player4Score = GameObject.Find("PlayerP4").GetComponent<Movement>().PlayerScore;

            Player1Anger = GameObject.Find("PlayerP1").GetComponent<Movement>().Anger;
            Player1Anxiety = GameObject.Find("PlayerP1").GetComponent<Movement>().Anxiety;
            Player1Energy = GameObject.Find("PlayerP1").GetComponent<Movement>().Energy;
            Player1Happiness = GameObject.Find("PlayerP1").GetComponent<Movement>().Happiness;
            Player1Sadness = GameObject.Find("PlayerP1").GetComponent<Movement>().Sadness;

            Player2Anger = GameObject.Find("PlayerP2").GetComponent<Movement>().Anger;
            Player2Anxiety = GameObject.Find("PlayerP2").GetComponent<Movement>().Anxiety;
            Player2Energy = GameObject.Find("PlayerP2").GetComponent<Movement>().Energy;
            Player2Happiness = GameObject.Find("PlayerP2").GetComponent<Movement>().Happiness;
            Player2Sadness = GameObject.Find("PlayerP2").GetComponent<Movement>().Sadness;

            Player3Anger = GameObject.Find("PlayerP3").GetComponent<Movement>().Anger;
            Player3Anxiety = GameObject.Find("PlayerP3").GetComponent<Movement>().Anxiety;
            Player3Energy = GameObject.Find("PlayerP3").GetComponent<Movement>().Energy;
            Player3Happiness = GameObject.Find("PlayerP3").GetComponent<Movement>().Happiness;
            Player3Sadness = GameObject.Find("PlayerP3").GetComponent<Movement>().Sadness;

            Player4Anger = GameObject.Find("PlayerP4").GetComponent<Movement>().Anger;
            Player4Anxiety = GameObject.Find("PlayerP4").GetComponent<Movement>().Anxiety;
            Player4Energy = GameObject.Find("PlayerP4").GetComponent<Movement>().Energy;
            Player4Happiness = GameObject.Find("PlayerP4").GetComponent<Movement>().Happiness;
            Player4Sadness = GameObject.Find("PlayerP4").GetComponent<Movement>().Sadness;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Ending");
        }

        finalScore = Player1Score + Player2Score + Player3Score + Player4Score;
        scoreText.text = ("Score: " + finalScore);
    }
}
