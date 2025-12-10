using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuEndlessJumper : MonoBehaviour
{
    #region Variables

    [SerializeField] GameObject Game, exitGO, LoadMenu;
    [SerializeField] Button NewStart, Continue, Exit, Menu;

    #endregion Variables


    #region Funciones Publicas 

    public void LoadMenuPrincipal()
    {
        SceneManager.LoadScene("MenuEndlessJumper");
    }
    public void LoadGameplay()
    {
        SceneManager.LoadScene("GameEndlessRunner");
    }
    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    #endregion Funciones Publicas
}
