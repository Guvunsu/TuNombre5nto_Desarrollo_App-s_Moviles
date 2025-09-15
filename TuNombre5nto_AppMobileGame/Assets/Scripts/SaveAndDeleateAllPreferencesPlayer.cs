using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveAndDeleateAllPreferencesPlayer : MonoBehaviour
{
    public GameManagerScore scritp_GameManagerScore;
    [SerializeField] TMP_InputField nameText_InputField;
    [SerializeField] string myNameIs_string = "MR.JhonWick";
    [SerializeField] Button catYellow_Button;
    [SerializeField] Button catBlack_Button;
    [SerializeField] Button save_Button;

    void Start()
    {
        LoadSettings();
    }
    void LoadSettings()
    {
        if (PlayerPrefs.HasKey("InputField_I_Choose_tHAT_cAT_nAME"))
        {
            nameText_InputField.text = PlayerPrefs.GetString("InputField_I_Choose_tHAT_cAT_nAME");
        } else
            nameText_InputField.text = myNameIs_string;
        PlayerPrefs.SetString("InputField_I_Choose_tHAT_cAT_nAME", myNameIs_string);
    }
    public void SetNamePrefCat()
    {
        PlayerPrefs.SetString("InputField_I_Choose_tHAT_cAT_nAME", nameText_InputField.text);
    }
    public void DeleteCatName()
    {
        if (PlayerPrefs.HasKey("InputField_I_Choose_tHAT_cAT_nAME"))
        {
            PlayerPrefs.DeleteKey("InputField_I_Choose_tHAT_cAT_nAME");
        } else
            PlayerPrefs.DeleteAll();
    }
}
