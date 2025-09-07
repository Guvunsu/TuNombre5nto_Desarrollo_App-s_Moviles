using TMPro;
using UnityEngine;

public class GameManagerScore : MonoBehaviour
{
    #region Variables

    #region scripts heredables
    public PanelManager script_PanelManager;
    public TimeManager script_TimeManager;
    #endregion scritps heredables

    #region Score
    [Header("Scores")]
    [SerializeField] int score_Happyness = 100;
    [SerializeField] int score_Satisfated = 100;
    [SerializeField] int score_Sleepness = 100;
    [SerializeField] int score_Amount = 5;
    [SerializeField] int Score_Decay = 1;
    [SerializeField] int score_Max = 100;
    [SerializeField] int score_Min = 0;
    #endregion Score

    #region TextMeshPro Update UI
    [Header("(TMP) UI")]
    [SerializeField] TextMeshProUGUI happynessText;
    [SerializeField] TextMeshProUGUI satisfatedText;
    [SerializeField] TextMeshProUGUI sleepnessText;
    #endregion TextMeshPro Update UI
    #endregion Variables 

    #region Unity Methods
    void Start()
    {
        StartScore();
        InvokeRepeating(nameof(Decrease3_Scores), 1f, 1f);
    }
    #endregion Unity Methods

    #region Score
    public void StartScore()
    {
        score_Happyness = 25;
        score_Satisfated = 25;
        score_Sleepness = 25;
    }
    public void Decrease3_Scores()
    {
        score_Happyness = Mathf.Max(score_Happyness - Score_Decay, score_Min);
        score_Satisfated = Mathf.Max(score_Satisfated - Score_Decay, score_Min);
        score_Sleepness = Mathf.Max(score_Sleepness - Score_Decay, score_Min);
        UpdateUI();
        IfScoreIsZero();
    }
    public void AddHappyness()
    {
        score_Happyness = Mathf.Max(score_Happyness + score_Amount, score_Max);
        UpdateUI();
        script_TimeManager.TimeDecrased();
        IfScoreIsZero();
    }
    public void AddSatisfated()
    {
        score_Satisfated = Mathf.Max(score_Satisfated + score_Amount, score_Max);
        UpdateUI();
        script_TimeManager.TimeDecrased();
        IfScoreIsZero();
    }
    public void AddSleepness()
    {
        score_Sleepness = Mathf.Max(score_Sleepness + score_Amount, score_Max);
        UpdateUI();
        script_TimeManager.TimeDecrased();
        IfScoreIsZero();
    }
    public void IfScoreIsZero()
    {
        if (score_Happyness == score_Min &&
         score_Satisfated == score_Min &&
         score_Sleepness == score_Min)
        {
            script_PanelManager.DeathPanel();
        }
    }
    #region UI Update
    public void UpdateUI()
    {

        if (happynessText != null) happynessText.text = $"{score_Happyness}";
        if (satisfatedText != null) satisfatedText.text = $"{score_Satisfated}";
        if (sleepnessText != null) sleepnessText.text = $"{score_Sleepness}";
    }
    #endregion UI Update

    #endregion Score
}