using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Configuración del Tiempo")]
    [SerializeField] TMP_Text timerText;
    [SerializeField] float interval = 1f;  // cada cuántos segundos baja el score
    private float timer;

    private float totalTime; // tiempo total transcurrido

    void Update()
    {
        TimeDecrased();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60f);
        int seconds = Mathf.FloorToInt(totalTime % 60f);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
    public void TimeDecrased()
    {
        
        totalTime += Time.deltaTime;
        UpdateTimerUI();

        // Intervalo para reducir stats
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
        }
    }
}
