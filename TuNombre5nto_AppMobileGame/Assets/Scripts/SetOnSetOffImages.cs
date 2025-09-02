using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;

public class SetOnSetOffImages : MonoBehaviour
{
    #region Variables 

    #region Variables Cats Image ElementsUI 
    [Header("Happiness")]
    [SerializeField] Image image_Happy_Yellow_Cat;
    [SerializeField] Image image_Happy_Black_White_Cat;
    [Header("Sadness")]
    [SerializeField] Image image_Sad_Yellow_Cat;
    [SerializeField] Image image_Sad_Black_White_Cat;
    [Header("TrySleep")]
    [SerializeField] Image image_Try_Sleep_Yellow_Cat;
    [SerializeField] Image image_Try_Sleep_Black_White_Cat;
    [Header("Sleeping 1 ZZZ")]
    [SerializeField] Image image_Sleeping_Yellow_Cat_1;
    [SerializeField] Image image_Sleeping_Black_White_Cat_1;
    [Header("Sleeping 2 zzz")]
    [SerializeField] Image image_Sleeping_Yellow_Cat_2;
    [SerializeField] Image image_Sleeping_Black_White_Cat_2;
    [Header("Sleeping 3 ZZZ")]
    [SerializeField] Image image_Sleeping_Yellow_Cat_3;
    [SerializeField] Image image_Sleeping_Black_White_Cat_3;

    #endregion Variables Cats Image ElementsUI

    #region Variables Things Image ElementUI
    [Header("Toys")]
    [SerializeField] Image[] images_Random_Play_Button;
    [SerializeField] Image currentImageIs;

    //[SerializeField] Image image_Toy_Gray;
    //[SerializeField] Image image_Toy_Black;

    //[SerializeField] Image image_Toy_Stamen_Color_Green;
    //[SerializeField] Image image_Toy_Stamen_Color_Purple;
    //[SerializeField] Image image_Toy_Stamen_Color_Blue;
    //[SerializeField] Image image_Toy_Stamen_Color_Orange;
    //[SerializeField] Image image_Toy_Stamen_Color_Yellow;
    //[SerializeField] Image image_Toy_Stamen_Color_Black;
    //[SerializeField] Image image_Toy_Stamen_Color_Pink;
    //[SerializeField] Image image_Toy_Stamen_Color_Brown;
    //[SerializeField] Image image_Toy_Stamen_Color_Gray;

    [Header("Food")]
    [SerializeField] Image image_Food;

    [Header("Water")]
    [SerializeField] Image image_Water;

    [Header("Sleeping")]
    [SerializeField] Image image_House;
    [SerializeField] Image image_Bed_Blue;
    [SerializeField] Image image_Bed_White;

    #endregion Variables Things Image ElementUI

    #region scripts heredables
    public ButtonsGameManager script_ButtonsGameManager;

    #endregion scripts heredables

    #region Corrutine
    Coroutine blinkBlinkImage_Corutine;
    #endregion  Corrutine

    #endregion Variables

    #region Public Unity Methods
    void Start()
    {

    }
    void Update()
    {

    }
    #endregion Public Unity Methods

    #region Private Methods

    #region Corutine Activation

    IEnumerator BlinkHappyness(Image image, float interval)
    {
        image.enabled = !image.enabled;
        yield return new WaitForSeconds(interval);
        // si quiero hacer que parpadie tantas veces implementar un ciclo for que inicie en 0 hasta cuantas veces max.
        // recuerda usar tu image indicado activado y un yield return new waitingforseconds y el tiempo
        // hacerlo de nuevo para desactivarlo
        // no se igual y no :/
        for (int i = 0; i < 3; i++)
        {
            image_Happy_Yellow_Cat.enabled = true;
            yield return new WaitForSeconds(0.5f);
            image_Happy_Yellow_Cat.enabled = false;
            yield return new WaitForSeconds(0.5f);
        }
        image_Happy_Yellow_Cat.enabled = true;
    }
    IEnumerator ShowFoodAndThenBlinkHappyness(Image image, float interval)
    {

        // aparece la comida, espera un tiempo, desaparece
        image_Food.enabled = true;
        yield return new WaitForSeconds(3f);
        image_Food.enabled = false;

        // Nikki esta feliz por un tiempo
        StartCoroutine(BlinkHappyness(image,interval));
    }
    void StartBlinkBlinkImage(Image image, float interval)
    {
        //inicia apagado para luego indicarle que empiece en una imagen especifico y tiempo
        StopBlinkBlinkImage();
        blinkBlinkImage_Corutine = StartCoroutine(BlinkHappyness(image, interval));
    }
    void StopBlinkBlinkImage()
    {
        //si no esta apagado, lo apaga
        if (blinkBlinkImage_Corutine != null)
        {
            StopCoroutine(blinkBlinkImage_Corutine);
            blinkBlinkImage_Corutine = null;
        }
    }

    #endregion Corutine Activation

    #endregion Private Methods

    #region Public Methods

    #region Activation Images
    public void ActivationImageFromPlayButton()
    {
        Debug.Log("Play Button activate");
        //revisa cada imagen y las apaga todas
        foreach (var image in images_Random_Play_Button)
        {
            image.enabled = false;
        }

        //escoge una y activa, las demas nope
        int randomImageIs = Random.Range(0, images_Random_Play_Button.Length);
        currentImageIs = images_Random_Play_Button[randomImageIs];
        currentImageIs.enabled = false;

        // Nikki esta feliz por un tiempo
        StartBlinkBlinkImage(image_Happy_Yellow_Cat, 0.5f);

    }
    public void ActivationImageFromFoodButton()
    {
        Debug.Log("Food Button activate");
        ShowFoodAndThenBlinkHappyness(image_Food, 3.33f);
        StartBlinkBlinkImage(image_Happy_Yellow_Cat, 0.5f);

    }
    public void ActivationImageFromWaterButton()
    {
        Debug.Log("Water Button activate");

    }
    public void ActivationImageFromSleepButton()
    {
        Debug.Log("Sleep Button activate");

    }
    #endregion Activation Images

    #endregion Public Methods

}
