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
        // Yellow Cat
        button_Food.onClick.AddListener(OnFoodPressed_Yellow_Cat);
        button_Water.onClick.AddListener(OnWaterPressed_Yellow_Cat);
        button_Sleep.onClick.AddListener(OnSleepPressed_Yellow_Cat);
        // Black and White Cat
        /* button_Food.onClick.AddListener(OnFoodPressed_Black_White_Cat);
         button_Water.onClick.AddListener(OnWaterPressed_Black_White_Cat);
         button_Sleep.onClick.AddListener(OnSleepPressed_Black_White_Cat);*/
    }
    #endregion Public Unity Methods

    #region Public Methods

    public void OnPlayPressed()
    {
        script_SetOnSetOffImages.ActivationImageFromPlayButton();
    }
    #region Yellow Cat
    public void OnFoodPressed_Yellow_Cat()
    {
        script_SetOnSetOffImages.ActivationImageFromFoodButton_Yellow_Cat();
    }
    public void OnWaterPressed_Yellow_Cat()
    {
        script_SetOnSetOffImages.ActivationImageFromWaterButton_Yellow_Cat();
    }
    public void OnSleepPressed_Yellow_Cat()
    {
        script_SetOnSetOffImages.ActivationImageFromSleepButton_Yellow_Cat();
    }
    #endregion Yellow Cat

   /* #region Black White Cat

    public void OnFoodPressed_Black_White_Cat()
    {
        script_SetOnSetOffImages.ActivationImageFromFoodButton_Yellow_Cat();
    }
    public void OnWaterPressed_Black_White_Cat()
    {
        script_SetOnSetOffImages.ActivationImageFromWaterButton_Yellow_Cat();
    }
    public void OnSleepPressed_Black_White_Cat()
    {
        script_SetOnSetOffImages.ActivationImageFromSleepButton_Yellow_Cat();
    }

    #endregion Black White Cat */

    #endregion Public Methods
}
