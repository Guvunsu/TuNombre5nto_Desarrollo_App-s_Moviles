using System.Collections;
using UnityEngine;

public class MagnetEffect : MonoBehaviour
{
    [Header("Configuración del Imán")]
    [SerializeField] GameObject magnetRadiusObject; 
    [SerializeField] float magnetDuration = 5f;

    bool isActive = false;

    void Awake()
    {
        if (magnetRadiusObject != null)
            magnetRadiusObject.SetActive(false);
    }

    public bool IsMagnetActive() => isActive;

    public void ActivateMagnet()
    {
        StopAllCoroutines();
        StartCoroutine(MagnetRoutine());
    }

    IEnumerator MagnetRoutine()
    {
        isActive = true;
        if (magnetRadiusObject != null) magnetRadiusObject.SetActive(true);
        yield return new WaitForSeconds(magnetDuration);
        if (magnetRadiusObject != null) magnetRadiusObject.SetActive(false);
        isActive = false;
    }
}
