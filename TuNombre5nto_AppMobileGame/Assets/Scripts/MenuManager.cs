using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    void Start()
    {

    }
    void Update()
    {

    }
    public void ButtonPLayGame()
    {
        if (menu != null)
        {
            menu.SetActive(true);
        }
    }
}
