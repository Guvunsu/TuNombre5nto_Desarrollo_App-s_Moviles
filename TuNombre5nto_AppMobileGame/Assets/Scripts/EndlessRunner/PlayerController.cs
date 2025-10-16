using UnityEngine;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour
{
    Vector3 dragStartPos;
    Touch touch;
    Vector3 horizontal;
    public float speed = 2.0f;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
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
        dragStartPos = Camera.main.ScreenToViewportPoint(touch.position);

    }
    void Dragging()
    {
        Debug.Log("Arrastre");
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

    }
    void DragRelease()
    {
        Debug.Log("Levante el dedo");

    }
}
