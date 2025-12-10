using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChangeManager : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] Button Load_MenuGame;
    [SerializeField] Button Load_MenuLevels;
    [SerializeField] Button Load_GameLevel1;
    [SerializeField] Button Load_GameLevel2;
    [SerializeField] Button Load_GameLevel3;
    [SerializeField] GameObject continueGame;
    [SerializeField] GameObject pauseGame;
    [SerializeField] GameObject gameOver;
    [SerializeField] Button continueG;
    [SerializeField] Button exit;
    public void GameOver()
    {
        gameOver.SetActive(true);
    }
    public void PauseGame()
    {
        pauseGame.SetActive(true);
    }   
    public void ContinueGame()
    {
        pauseGame.SetActive(false);
    }
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }
    public void LoadLevelThree()
    {
        SceneManager.LoadScene("LevelThree");
    }
    public void LoadMenuPrincipal()
    {
        SceneManager.LoadScene("MenuGame");
    }
    public void LoadMenuLevels()
    {
        SceneManager.LoadScene("MenuLevels");
    }
    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
