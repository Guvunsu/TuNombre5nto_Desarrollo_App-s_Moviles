using TMPro;
using UnityEngine;

public class ScoreCoins : MonoBehaviour
{
    [Header("Puntuación")]
    public int scoreCoins;
    public int highScore;

    [Header("UI Score")]
    [SerializeField] TMP_Text scoreGeneral;
    [SerializeField] TMP_Text highScoreText; 

    void Start()
    {
        scoreCoins = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScorenUI();
    }

    public void AddCoinScore()
    {
        scoreCoins += 1;
        CheckHighScore();
        UpdateScorenUI();
    }

    public void AddDistanceScore()
    {
        CheckHighScore();
        UpdateScorenUI();
    }

    void CheckHighScore()
    {
        if (scoreCoins > highScore)
        {
            highScore = scoreCoins;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    void UpdateScorenUI()
    {
        if (scoreGeneral != null)
            scoreGeneral.text = scoreCoins.ToString();

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore.ToString();
    }
}
