using System;
using System.Collections;
using Unity.Collections;
using Unity.Mathematics;
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

    [Header("Food || Water || Vaccine")]
    [SerializeField] GameObject foodObject;
    [SerializeField] GameObject waterObject;
    [SerializeField] GameObject vaccineObject;

    [Header("Sleeping Objects")]
    [SerializeField] GameObject[] GameObject_Array_Beds;
    [SerializeField] GameObject currentObject_Bed;
    #endregion Variables Toys / Items

    #endregion Variables

    #region Public Methods

    #region Des/Activation Objects
    public void ActivationFromFoodOrWaterOrVaccineButton(string textButton)
    {
        GameObject currentObjectIs = null;
        foodObject.SetActive(false);
        waterObject.SetActive(false);

        if (textButton == "Food")
        {
            currentObjectIs = foodObject;
        }
        if (textButton == "Water")
        {
            currentObjectIs = waterObject;
        }
        if (textButton == "Vaccine")
        {
            currentObjectIs = vaccineObject;
        }

        currentObjectIs.SetActive(true);
        StartCoroutine(CurrentObjectDesactivation(currentObjectIs, 3.33f));
    }
    public void ActivationFromPlayOrSleepButton(string textButton)
    {
        if (textButton == "Play")
        {
            Debug.Log("Play Button activate");

            foreach (var toy_Verification in GameObjects_Array_Toys)
            {
                toy_Verification.SetActive(false);
            }
            if (GameObjects_Array_Toys.Length > 0)
            {
                int random_Toy_Selection = UnityEngine.Random.Range(0, GameObjects_Array_Toys.Length);
                currentObject_Toy = GameObjects_Array_Toys[random_Toy_Selection];

                currentObject_Toy.SetActive(true);
                StartCoroutine(CurrentObjectDesactivation(currentObject_Toy, 3.33f));
            }
        } else if (textButton == "Sleep")
        {
            Debug.Log("Sleep Button activate");
            foreach (var bed_veriification in GameObject_Array_Beds)
            {
                bed_veriification.SetActive(false);
            }
            if (GameObject_Array_Beds.Length > 0)
            {
                int random_Bed_Selection = UnityEngine.Random.Range(0, GameObject_Array_Beds.Length);
                currentObject_Bed = GameObject_Array_Beds[random_Bed_Selection];

                currentObject_Bed.SetActive(true);
                StartCoroutine(CurrentObjectDesactivation(currentObject_Bed, 3.33f));
            }
        }
    }
    #endregion Des/Activation Objects

    #endregion Public Methods

    #region IEnumerator
    public IEnumerator CurrentObjectDesactivation(GameObject currentObjectDesactivation, float visibleTimeCurrentObject)
    {
        yield return new WaitForSeconds(visibleTimeCurrentObject);
        if (currentObjectDesactivation != null)
        {
            currentObjectDesactivation.SetActive(false);
        }
        print("Coroutine ended:" + Time.time + "Seconds");
    }
    #endregion IEnumerator
}