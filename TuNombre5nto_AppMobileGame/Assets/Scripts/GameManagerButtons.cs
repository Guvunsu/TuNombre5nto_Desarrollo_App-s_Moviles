using UnityEngine;
using UnityEngine.UI;
public class GameManagerButtons : MonoBehaviour
{
    #region Variables

    #region scripts heredables
    public GameManagerActivationGameObjectsAndDesactivated script_GameManagerActivationGameObjectsAndDesactivated;
    public GameManagerScore script_GameManagerScore;
  //  public PanelManager script_PanelManager;
    #endregion scritps heredables

    #region Button
    [SerializeField] Button button_Play;
    [SerializeField] Button button_Food;
    [SerializeField] Button button_Water;
    [SerializeField] Button button_Sleep;

    #endregion Button

    #endregion Variables

    #region Public Unity Methods
    void Start()
    {
        button_Play.onClick.AddListener(OnPlayPressed);
        button_Food.onClick.AddListener(OnFoodPressed);
        button_Water.onClick.AddListener(OnWaterPressed);
        button_Sleep.onClick.AddListener(OnSleepPressed);
    }
    #endregion Public Unity Methods

    #region Public Methods

    public void OnPlayPressed()
    {
        script_GameManagerActivationGameObjectsAndDesactivated.ActivationFromPlayButton();
        script_GameManagerScore.AddHappyness();
    }
    public void OnFoodPressed()
    {
        script_GameManagerActivationGameObjectsAndDesactivated.ActivationFromFoodButton();
        script_GameManagerScore.AddSatisfated();
    }
    public void OnWaterPressed()
    {
        script_GameManagerActivationGameObjectsAndDesactivated.ActivationFromWaterButton();
        script_GameManagerScore.AddSatisfated();
    }
    public void OnSleepPressed()
    {
        script_GameManagerActivationGameObjectsAndDesactivated.ActivationFromSleepButton();
        script_GameManagerScore.AddSleepness();
    }

    #endregion Public Methods
}