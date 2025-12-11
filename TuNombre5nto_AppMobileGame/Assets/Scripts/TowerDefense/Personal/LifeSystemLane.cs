using UnityEngine;

public class LifeSystemLane : MonoBehaviour
{
    [Header("vidas por línea")]
    public int hearts = 1;

    [Header("Referencias")]
    public SceneChangeManager sceneManager;

    public void DamageLane(int damage)
    {
        hearts -= damage;

        if (hearts <= 0)
        {
            hearts = 0;
            LoseGame();
        }
    }

    private void LoseGame()
    {
        Debug.Log("¡Derrota! Las vidas llegaron a cero.");
        Time.timeScale = 0;
        sceneManager.GameOver();
    }
}