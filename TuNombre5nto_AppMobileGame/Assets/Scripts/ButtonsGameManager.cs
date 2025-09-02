using UnityEngine;
using UnityEngine.UI;


public class ButtonsGameManager : MonoBehaviour
{
    #region Variables

    #region scripts heredables
    public SetOnSetOffImages script_SetOnSetOffImages;

    #endregion scritps heredables

    #region Button
    [SerializeField] Button button_Play;
    [SerializeField] Button button_Food;
    [SerializeField] Button button_Water;
    [SerializeField] Button button_Sleep;

    #endregion Button

    #region FadeCanvasGroup
    [SerializeField] CanvasGroup images_CanvasGroup;
    [SerializeField] float fadeDuration = 9.00f;

    #endregion FadeCanvasGroup

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
        script_SetOnSetOffImages.ActivationImageFromPlayButton();
    }
    public void OnFoodPressed()
    {
        script_SetOnSetOffImages.ActivationImageFromFoodButton();
    }
    public void OnWaterPressed()
    {
        script_SetOnSetOffImages.ActivationImageFromWaterButton();
    }
    public void OnSleepPressed()
    {
        script_SetOnSetOffImages.ActivationImageFromSleepButton();
    }
    #endregion Public Methods
}
