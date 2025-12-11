using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EconomyManager : MonoBehaviour
{
    public static EconomyManager instance;

    [Header("Economía del juego")]
    public int currentMoney = 5000;
    public int startMoney = 5000;

    [Header("UI")]
    public TextMeshProUGUI moneyText;   // Arrastra un Text del canvas

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        currentMoney = startMoney;
        UpdateUI();
    }

    // -----------------------------
    //        AGREGAR DINERO
    // -----------------------------
    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateUI();
    }

    // -----------------------------
    //      QUITAR DINERO (TORRES)
    // -----------------------------
    public bool SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateUI();
            return true;
        }

        return false; // No alcanza
    }

    // -----------------------------
    //    ACTUALIZA TEXTO EN UI
    // -----------------------------
    private void UpdateUI()
    {
        if (moneyText != null)
            moneyText.text = "$" + currentMoney;
    }
}
