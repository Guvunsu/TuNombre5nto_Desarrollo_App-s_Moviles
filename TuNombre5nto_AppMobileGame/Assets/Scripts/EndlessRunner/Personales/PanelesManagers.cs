using UnityEngine;

public class PanelesManagers : MonoBehaviour
{
    #region Variables
    #region Paneles
    [Header("Paneles")]
    [SerializeField] GameObject panel_death;
    [SerializeField] GameObject panel_PauseGame;

    bool pauseGame;
    bool deadGame;
    #endregion Paneles
    #endregion Variables

    #region Unity Methods
    void Start()
    {
        panel_death.SetActive(false);
        panel_PauseGame.SetActive(false);
    }
    #endregion Unity Methods

    #region Dead Panel
    public void DeathPanel()
    {
        deadGame = !deadGame;
        if (deadGame)
        {
            Time.timeScale = 1;
            panel_death.SetActive(false);
        } else
            Time.timeScale = 0;
        panel_death.SetActive(true);
    }
    public void PauseGame()
    {
        pauseGame = !pauseGame;
        if (pauseGame)
        {
            Time.timeScale = 1;
            panel_PauseGame.SetActive(false);

        } else
        {
            Time.timeScale = 0;
            panel_PauseGame.SetActive(true);
        }
    }

    #endregion Dead Panel
}
