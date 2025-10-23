using UnityEngine;

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
            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
    }
    void DragStart()
    {
        Debug.Log("Empeze a tocar");
        dragStartPos = Camera.main.ScreenToWorldPoint(dragStartPos);
    }

    void Dragging()
    {
        Debug.Log(Camera.main.ScreenToWorldPoint(dragStartPos));
    }

    void DragRelease()
    {
        Debug.Log("Termine de a tocar");

    }
}
