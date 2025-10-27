//using UnityEngine;
//using System.Collections.Generic;
//using UnityEngine.Rendering.UI;

//public class ConfinerMovement : MonoBehaviour
//{
//    public DeadMomentWhenYouFall script_DeadMomentWhenYouFall;
//    [SerializeField] Transform playerTransform;
//    Vector3 newYPos = new Vector3();
//    Vector3 highestPlayerPoint;
//    float screenHeight;
//    bool canMove;
//    private void Start()
//    {
//        screenHeight = Camera.main.orthographicSize * 2;
//        Debug.Log(screenHeight);
//        highestPlayerPoint = Vector3.zero;
//        canMove = true;
//    }
//    void Update()
//    {
//        newYPos.y = playerTransform.position.y;
//        transform.position = newYPos;

//        if (playerTransform.position.y > highestPlayerPoint.y)
//        {
//            highestPlayerPoint = playerTransform.position;
//        }
//        if (canMove)
//        {
//            newYPos.y = playerTransform.position.y;
//            transform.position = newYPos;
//        }
//        GetPlayerDistance();
//    }
//    private void GetPlayerDistance()
//    {
//        if (highestPlayerPoint.y - playerTransform.position.y > screenHeight)
//        {
//            canMove = false;
//            script_DeadMomentWhenYouFall.DeadPlayer();
//            //hacer que llame la muerte ya que cehca la altura maxima que tiene el jugador, lo resta y debe ser menor a la altura de la pantalla
//        }
//    }
//}using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class ConfinerMovement : MonoBehaviour
{
    public DeadMomentWhenYouFall script_DeadMomentWhenYouFall;
    [SerializeField] Transform playerTransform;
    Vector3 newYPos = new Vector3();
    Vector3 highestPlayerPoint;
    float screenHeight;
    bool canMove;
    bool playerIsDead; // NUEVO: detecta si el jugador ya murió

    private void Start()
    {
        screenHeight = Camera.main.orthographicSize * 2;
        Debug.Log(screenHeight);
        highestPlayerPoint = Vector3.zero;
        canMove = true;
        playerIsDead = false;

        // Conectamos callback al script de muerte (para detectar en tiempo real)
        if (script_DeadMomentWhenYouFall != null)
        {
            script_DeadMomentWhenYouFall.OnPlayerDead += StopConfinerMovement;
        }
    }

    void Update()
    {
        if (playerIsDead) return; // no seguir si el jugador murió

        newYPos.y = playerTransform.position.y;
        transform.position = newYPos;

        if (playerTransform.position.y > highestPlayerPoint.y)
        {
            highestPlayerPoint = playerTransform.position;
        }
        if (canMove)
        {
            newYPos.y = playerTransform.position.y;
            transform.position = newYPos;
        }

        GetPlayerDistance();
    }

    private void GetPlayerDistance()
    {
        if (highestPlayerPoint.y - playerTransform.position.y > screenHeight)
        {
            canMove = false;
            playerIsDead = true;
            script_DeadMomentWhenYouFall.DeadPlayer();
        }
    }

    // NUEVO: detiene el movimiento cuando el evento de muerte se dispara
    public void StopConfinerMovement()
    {
        canMove = false;
        playerIsDead = true;
    }

    private void OnDestroy()
    {
        // Desuscribir el evento al destruir el objeto
        if (script_DeadMomentWhenYouFall != null)
        {
            script_DeadMomentWhenYouFall.OnPlayerDead -= StopConfinerMovement;
        }
    }
}
