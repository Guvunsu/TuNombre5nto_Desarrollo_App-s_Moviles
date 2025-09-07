using UnityEngine;

public class GameManagerActivationGameObjectsAndDesactivated : MonoBehaviour
{
    #region Variables

    #region Variables Cats Sprite Objects
    [Header("Happiness")]
    [SerializeField] GameObject happy_Yellow_Cat;
    [SerializeField] GameObject happy_Black_White_Cat;

    [Header("Sadness")]
    [SerializeField] GameObject sad_Yellow_Cat;
    [SerializeField] GameObject sad_Black_White_Cat;

    [Header("TrySleep")]
    [SerializeField] GameObject trySleep_Yellow_Cat;
    [SerializeField] GameObject trySleep_Black_White_Cat;

    [Header("Sleeping 1 ZZZ")]
    [SerializeField] GameObject sleeping_Yellow_Cat_1;
    [SerializeField] GameObject sleeping_Black_White_Cat_1;

    [Header("Sleeping 2 ZZZ")]
    [SerializeField] GameObject sleeping_Yellow_Cat_2;
    [SerializeField] GameObject sleeping_Black_White_Cat_2;

    [Header("Sleeping 3 ZZZ")]
    [SerializeField] GameObject sleeping_Yellow_Cat_3;
    [SerializeField] GameObject sleeping_Black_White_Cat_3;
    #endregion Variables Cats Sprite Objects

    #region Variables Toys / Items
    [Header("Toys")]
    [SerializeField] GameObject[] GameObjects_Array_Toys;
    private GameObject currentObject_Toy;

    [Header("Food & Water")]
    [SerializeField] GameObject foodObject;
    [SerializeField] GameObject waterObject;

    [Header("Sleeping Objects")]
    [SerializeField] GameObject[] GameObject_Array_Beds;
    [SerializeField] GameObject currentObject_Bed;
    #endregion Variables Toys / Items

    #region Timer
    [Header("Timer Visible GameObjects In Screen")]
    [SerializeField] float visibleTimeCurrentToy = 3.33f;
    [SerializeField] float visibleTimeFoodObject = 3.33f;
    [SerializeField] float visibleTimeCurrentBed = 3.33f;
    [SerializeField] float visibleTimeWaterObject = 3.33f;
    #endregion Timer

    #endregion Variables

    #region Public Methods

    #region Activation Objects
    public void Desactived3GameObjects()
    {
        currentObject_Toy.SetActive(false);
        foodObject.SetActive(false);
        waterObject.SetActive(false);
    }
    public void ActivationFromPlayButton()
    {
        Debug.Log("Play Button activate");

        foreach (var toy_Verification in GameObjects_Array_Toys)
        {
            toy_Verification.SetActive(false);
        }

        int random_Toy_Selection = Random.Range(0, GameObjects_Array_Toys.Length);
        currentObject_Toy = GameObjects_Array_Toys[random_Toy_Selection];

        currentObject_Toy.SetActive(true);
        Invoke(nameof(Desactived3GameObjects), visibleTimeCurrentToy);
    }
    public void ActivationFromFoodButton()
    {
        Debug.Log("Food Button activate");
        if (!foodObject.activeSelf)
        {
            foodObject.SetActive(true);
            Invoke(nameof(Desactived3GameObjects), visibleTimeFoodObject);
        }
    }
    public void ActivationFromWaterButton()
    {
        Debug.Log("Water Button activate");
        if (!waterObject.activeSelf)
        {
            waterObject.SetActive(true);
            Invoke(nameof(Desactived3GameObjects), visibleTimeWaterObject);
        }
    }
    public void ActivationFromSleepButton()
    {
        Debug.Log("Sleep Button activate");
        foreach (var bed_veriification in GameObject_Array_Beds)
        {
            bed_veriification.SetActive(false);
        }

        int random_Bed_Selection = Random.Range(0, GameObject_Array_Beds.Length);
        currentObject_Bed = GameObject_Array_Beds[random_Bed_Selection];

        currentObject_Bed.SetActive(true);
        Invoke(nameof(Desactived3GameObjects), visibleTimeCurrentBed);
    }

    #endregion Activation Objects

    #endregion Public Methods
}