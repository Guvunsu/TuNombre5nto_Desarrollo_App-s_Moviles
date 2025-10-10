using UnityEngine;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour
{
    Vector3 dragStartPos;
    Touch touch;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            if (touch.phase != TouchPhase.Ended)
            {
                DragRelease();
            }
        }
    }
    void DragStart()
    {
        Debug.Log("Toque la pantalla");
        dragStartPos= Camera.main.ScreenToViewportPoint(touch.position);

    }
    void Dragging()
    {
        Debug.Log("Arrastre");

    }
    void DragRelease()
    {
        Debug.Log("Levante el dedo");

    }
}
