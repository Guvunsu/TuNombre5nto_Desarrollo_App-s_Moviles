using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Configuración del Tiempo")]
    [SerializeField] TMP_Text timerText;
    [SerializeField] float decayTime = 1f;
     float totalTime;

    public Action DecayTimer_Score;

    void Start()
    {
        StartCoroutine(TickTackPum_Clock());
    }
    void UpdateTimerUI()
    {
        int hours = Mathf.FloorToInt(totalTime / 3600f);
        int minutes = Mathf.FloorToInt(totalTime % 3600f / 60f);
        int seconds = Mathf.FloorToInt(totalTime % 60f);
        timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
    }
    public void ResetearTiempo()
    {
        totalTime = 0f;
    }
    public IEnumerator TickTackPum_Clock()
    {
        while (true)
        {
            yield return new WaitForSeconds(decayTime);
            totalTime += decayTime;
            UpdateTimerUI();
            DecayTimer_Score.Invoke();
        }
    }
}
