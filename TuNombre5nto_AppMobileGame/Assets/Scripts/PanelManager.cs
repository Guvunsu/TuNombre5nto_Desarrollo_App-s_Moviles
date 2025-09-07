using UnityEngine;

public class PanelManager : MonoBehaviour
{
    //hacer un metodo de chequeo para verificar si el gato a muerto y tener la opcion de escoger el nuevo gato e iniciar de nuevo gato
    // guardadno el dato del gato y tiempo vivo
    #region Variables
    #region Paneles
    [Header("Paneles")]
    [SerializeField] GameObject panel_death;
    //[SerializeField] GameObject panel_Choose_Cat;
    #endregion Paneles
    #endregion Variables

    #region Unity Methods
    void Start()
    {
        if (panel_death != null)
        {
            panel_death.SetActive(false);
        }
    }
    #endregion Unity Methods

    #region Dead Panel
    public void DeathPanel()
    {
        panel_death.SetActive(true);
    }
    #endregion Dead Panel

    //#region ChooseCat
    //public void ChooseCatStartAgain() { }
    //#endregion ChooseCat
}
