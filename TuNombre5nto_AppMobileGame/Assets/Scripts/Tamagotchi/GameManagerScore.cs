using System.Collections;
using TMPro;
using UnityEngine;
public class GameManagerScore : MonoBehaviour
{
    #region Variables

    #region scripts 
    public PanelManager script_PanelManager;
    public TimeManager script_TimeManager;
    //public MenuManager script_MenuManager;
    public SaveAndDeleateAllPreferencesPlayer script_SaveAndDeleateAllPreferencesPlayer;
    #endregion scritps

    #region Score

    [Header("Initialized Scores")]
    [SerializeField] int score_Happyness = 25;
    [SerializeField] int score_Satisfated = 25;
    [SerializeField] int score_Sleepness = 25;

    [Header("Scores")]
    [SerializeField] float Score_Decay = 0.1f;
    [SerializeField] int score_Max = 100;
    [SerializeField] int score_Min = 0;
    #endregion Score

    #region Health
    [Header("Enfermedad")]
    public bool ImSickness = false;
    [SerializeField] TMP_Text IfSickness_Text;
    [SerializeField] float RandomPorcentage_Sickness = 0.25f;
    #endregion Health

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
        script_TimeManager.DecayTimer_Score += UpdateMinusScore;
        UpdateUI();
    }
    #endregion Unity Methods

    #region UI Update
    public void UpdateUI()
    {

        if (happynessText != null) happynessText.text = $"{score_Happyness}";
        if (satisfatedText != null) satisfatedText.text = $"{score_Satisfated}";
        if (sleepnessText != null) sleepnessText.text = $"{score_Sleepness}";
        if (sleepnessText != null) IfSickness_Text.text = ImSickness ? "NO" : "YES";
    }
    #endregion UI Update

    #region Score
    public void UpdatePlusScore(ref int score_Amount)
    {
        score_Amount = Mathf.Min(score_Amount + 5, score_Max);
        UpdateUI();
        TryGetSick();
    }
    public void UpdateMinusScore()
    {
        score_Happyness = Mathf.Max(score_Happyness - Mathf.FloorToInt(Score_Decay), score_Min);
        score_Satisfated = Mathf.Max(score_Satisfated - Mathf.FloorToInt(Score_Decay), score_Min);
        score_Sleepness = Mathf.Max(score_Sleepness - Mathf.FloorToInt(Score_Decay), score_Min);
        UpdateUI();
        TryGetSick();
        IfScoreIsZero();
    }
    public void IfScoreIsZero()
    {
        if (score_Happyness == score_Min &&
         score_Satisfated == score_Min &&
         score_Sleepness == score_Min &&
                ImSickness == true)
        {
            script_PanelManager.DeathPanel();
            script_TimeManager.ResetearTiempo();
            Time.timeScale = 1;
            script_SaveAndDeleateAllPreferencesPlayer.DeleteCatName();
        }
    }

    public void AddHappyness() => UpdatePlusScore(ref score_Happyness);
    public void AddSatisfated() => UpdatePlusScore(ref score_Satisfated);
    public void AddSleepness() => UpdatePlusScore(ref score_Sleepness);

    #endregion Score

    #region Sickness/Cure
    void TryGetSick()
    {
        if (!ImSickness)
        {
            float randomValue = UnityEngine.Random.value;
            if (randomValue <= RandomPorcentage_Sickness)
            {
                ImSickness = true;
                UpdateUI();
            }
        }
    }
    public void Cure()
    {
        if (ImSickness)
        {
            ImSickness = false;
            UpdateUI();
        }
    }
    #endregion Sickness/Cure
}