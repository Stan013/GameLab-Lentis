using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text FinalScoreText;
    public Text Player1Score;
    public Text Player2Score;
    public Text Player3Score;
    public Text Player4Score;
    public void Start()
    {
        FinalScoreText.text = ("Team Score: " + ScoreManager.finalScore);
        Player1Score.text = ("Speler 1 Score: " + ScoreManager.Player1Score);
        Player2Score.text = ("Speler 2 Score: " + ScoreManager.Player2Score);
        Player3Score.text = ("Speler 3 Score: " + ScoreManager.Player3Score);
        Player4Score.text = ("Speler 4 Score: " + ScoreManager.Player4Score);
    }
}
