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

    #region Public Methods

    public void OnPlayPressed()
    {
        script_GameManagerActivationGameObjectsAndDesactivated.ActivationFromPlayOrSleepButton("Play");
        script_GameManagerScore.AddHappyness();
    }
    public void OnFoodPressed()
    {
        script_GameManagerActivationGameObjectsAndDesactivated.ActivationFromFoodOrWaterOrVaccineButton("Food");
        script_GameManagerScore.AddSatisfated();
    }
    public void OnWaterPressed()
    {
        script_GameManagerActivationGameObjectsAndDesactivated.ActivationFromFoodOrWaterOrVaccineButton("Water");
        script_GameManagerScore.AddSatisfated();
    }
    public void OnVaccinePressed()
    {
        script_GameManagerActivationGameObjectsAndDesactivated.ActivationFromFoodOrWaterOrVaccineButton("Vaccine");
        script_GameManagerScore.Cure();
    }
    public void OnSleepPressed()
    {
        script_GameManagerActivationGameObjectsAndDesactivated.ActivationFromPlayOrSleepButton("Sleep");
        script_GameManagerScore.AddSleepness();
    }

    #endregion Public Methods
}