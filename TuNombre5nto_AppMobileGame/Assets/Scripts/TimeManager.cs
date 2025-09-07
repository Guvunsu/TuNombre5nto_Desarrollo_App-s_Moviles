using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Configuración del Tiempo")]
    [SerializeField] TMP_Text timerText;
    [SerializeField] float decayTime = 1f;
    private float timer;
    private float totalTime;

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
        timer += Time.deltaTime;
        if (timer >= decayTime)
        {
            timer = 0f;
        }
    }
}
