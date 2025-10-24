using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dragStartPos;
    Vector3 horizontal;
    Touch touch;
    [SerializeField] float speed = 2.0f;
    Rigidbody2D rb;
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
        horizontal = new Vector3(transform.position.x + dragStartPos.x, 0, 0).normalized;
        if (horizontal.x > 0)
        {
            rb.linearVelocityX = dragStartPos.x * speed * Time.deltaTime;
            Debug.Log("Derecha");
        }
        else if (horizontal.x < 0)
        {
            rb.linearVelocityX = dragStartPos.x * speed * Time.deltaTime;
            Debug.Log("Izquierda");
        }
        Debug.Log(Camera.main.ScreenToWorldPoint(dragStartPos));
    }

    void DragRelease()
    {
        rb.linearVelocityX = 0;
        Debug.Log("Termine de a tocar");

    }
}
