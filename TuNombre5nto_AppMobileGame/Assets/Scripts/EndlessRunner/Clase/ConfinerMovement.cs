using UnityEngine;
using System.Collections.Generic;

public class ConfinerMovement : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector3 newYPos = new Vector3();
    void Update()
    {
        newYPos.y = playerTransform.position.y;
        transform.position = newYPos;
    }
}