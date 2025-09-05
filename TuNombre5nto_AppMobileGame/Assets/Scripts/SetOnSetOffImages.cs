using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;

public class SetOnSetOffImages : MonoBehaviour
{
    // modificar mi script para que sean gameobjects con sprites
    // hacer que images_Random_Play_Button sea gameobjects y con random.range de GO
    // a los objetos (items) sean gameobjects
    //qu9itar coroutine y ienuramator
    //CONSIDERAR una Animation
    // modificar y cambiar nombres de metodos de activation para activar el object y desactivarlo despues de un yiel return waitingnewseconds
   //opir y pegar en un nuevo script con un nombre debido y olvidar que eran images
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
    [SerializeField] public ButtonsGameManager script_ButtonsGameManager;

    #endregion scripts heredables

    #region Corrutine
    Coroutine blinkBlinkImage_Corutine;
    #endregion  Corrutine

    #endregion Variables

    #region Public Unity Methods
    //void Start()
    //{

    //}
    //void Update()
    //{

    //}
    #endregion Public Unity Methods

    #region Private Methods

    #region Corutine Activation

    IEnumerator BlinkHappyness(Image image, float interval = 3.33f)
    {
        Debug.LogWarning("pregunto si no es igual a mi imagen activada o desactivada");
        image.enabled = !image.enabled;
        Debug.LogWarning("ejecuto el regreso de mis segundos de mi intervalo de 3.33f");
        yield return new WaitForSeconds(interval);
        // si quiero hacer que parpadie tantas veces implementar un ciclo for que inicie en 0 hasta cuantas veces max.
        // recuerda usar tu image indicado activado y un yield return new waitingforseconds y el tiempo
        // hacerlo de nuevo para desactivarlo
        // no se igual y no :/
        Debug.LogWarning("Entro mi mi ciclo y ejecturara 3 veces de activar y desactivar mi imagen en tantos segundos ");
        for (int i = 0; i < 3; i++)
        {
            Debug.LogWarning("Entro al ciclo ?");
            image_Happy_Yellow_Cat.enabled = true;
            yield return new WaitForSeconds(interval);
            image_Happy_Yellow_Cat.enabled = false;
            yield return new WaitForSeconds(3.33f);
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
        StartCoroutine(BlinkHappyness(image, interval));
    }
    void StartBlinkBlinkImage(Image image, float interval = 3.33f)
    {
        Debug.Log("Ejecuto BlinkHapyness? ");
        BlinkHappyness(image, interval);
        Debug.LogWarning("no?");

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
    #region Cat Yellow 
    public void ActivationImageFromFoodButton_Yellow_Cat()
    {
        Debug.Log("Food Button activate");
        ShowFoodAndThenBlinkHappyness(image_Food, 3.33f);
        StartBlinkBlinkImage(image_Happy_Yellow_Cat, 0.5f);

    }
    public void ActivationImageFromWaterButton_Yellow_Cat()
    {

        Debug.Log("Water Button activate");
        ShowFoodAndThenBlinkHappyness(image_Water, 3.33f);
        StartBlinkBlinkImage(image_Happy_Yellow_Cat, 3.33f);


    }
    public void ActivationImageFromSleepButton_Yellow_Cat()
    {
        Debug.Log("Sleep Button activate");
        ShowFoodAndThenBlinkHappyness(image_Sleeping_Yellow_Cat_1, 1.33f);
        ShowFoodAndThenBlinkHappyness(image_Sleeping_Yellow_Cat_2, 1.33f);
        ShowFoodAndThenBlinkHappyness(image_Sleeping_Yellow_Cat_3, 1.33f);
        StartBlinkBlinkImage(image_Happy_Yellow_Cat, 3.33f);
    }
    #endregion Cat Yellow

    /* #region Black & White Cat

     public void ActivationImageFromFoodButton_Black_White_Cat()
     {
         Debug.Log("Food Button activate");
         ShowFoodAndThenBlinkHappyness(image_Food, 3.33f);
         StartBlinkBlinkImage(image_Happy_Black_White_Cat, 0.5f);

     }
     public void ActivationImageFromWaterButton_Black_White_Cat()
     {

         Debug.Log("Water Button activate");
         ShowFoodAndThenBlinkHappyness(image_Water, 3.33f);
         StartBlinkBlinkImage(image_Happy_Black_White_Cat, 3.33f);


     }
     public void ActivationImageFromSleepButton_Black_White_Cat()
     {
         Debug.Log("Sleep Button activate");
         ShowFoodAndThenBlinkHappyness(image_Sleeping_Black_White_Cat_1, 1.33f);
         ShowFoodAndThenBlinkHappyness(image_Sleeping_Black_White_Cat_2, 1.33f);
         ShowFoodAndThenBlinkHappyness(image_Sleeping_Black_White_Cat_3, 1.33f);
         StartBlinkBlinkImage(image_Happy_Black_White_Cat, 3.33f);

         #endregion Black & White cat*/

    #endregion Activation Images

    #endregion Public Methods

}
