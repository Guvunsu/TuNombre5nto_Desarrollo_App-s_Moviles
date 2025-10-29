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
    bool isPlayerDead;

    private void Start()
    {
        screenHeight = Camera.main.orthographicSize * 2;
        Debug.Log(screenHeight);
        highestPlayerPoint = Vector3.zero;
        canMove = true;
        isPlayerDead = false;

        if (script_DeadMomentWhenYouFall != null)
        {
            script_DeadMomentWhenYouFall.OnPlayerDead += StopConfinerMovement;
        }
    }

    void Update()
    {
        if (isPlayerDead) return;

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
            isPlayerDead = true;
            script_DeadMomentWhenYouFall.DeadPlayer();
        }
    }
    public void StopConfinerMovement()
    {
        canMove = false;
        isPlayerDead = true;
    }

    private void OnDestroy()
    {
        if (script_DeadMomentWhenYouFall != null)
        {
            script_DeadMomentWhenYouFall.OnPlayerDead -= StopConfinerMovement;
        }
    }
}
