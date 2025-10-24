using UnityEngine;
using TMPro;

public class DistanceJumpManager : MonoBehaviour
{
    [Header("Puntuación")]
    public int scoreDistance;
    public int scoreCoins;

    [Header("UI Score")]
    [SerializeField] TMP_Text scoreGeneral;

    void Start()
    {
        scoreCoins = 0;
        scoreDistance = 0;
        UpdateScorenUI();
    }

    public void AddCoinScore()
    {
        scoreCoins += 1;
        UpdateScorenUI();
    }
    public void AddDistanceScore()
    {

        UpdateScorenUI();
    }
    void UpdateScorenUI()
    {
        if (scoreGeneral != null)
            scoreGeneral.text = "x " + scoreCoins.ToString();
    }
}
