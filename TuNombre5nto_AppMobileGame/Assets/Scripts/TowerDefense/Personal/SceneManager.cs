using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] GameObject panel_MenuGame;
    [SerializeField] GameObject panel_MenuLevel;
    [SerializeField] GameObject panel_GameLevel1;
    [SerializeField] GameObject panel_GameLevel2;
    [SerializeField] GameObject panel_GameLevel3;

    public void ChangeLevelOne()
    {
        panel_GameLevel1.SetActive(true);
        panel_GameLevel2.SetActive(false);
        panel_GameLevel3.SetActive(false);
    }
    public void ChangeLevelTwo()
    {
        panel_GameLevel1.SetActive(false);
        panel_GameLevel2.SetActive(true);
        panel_GameLevel3.SetActive(false);
    }
    public void ChangeLevelThree()
    {
        panel_GameLevel1.SetActive(false);
        panel_GameLevel2.SetActive(false);
        panel_GameLevel3.SetActive(true);
    }
    public void MenuLevels()
    {
        panel_MenuLevel.SetActive(true);
    }
    public void MenuGame()
    {
        panel_MenuGame.SetActive(true);
    }
}
