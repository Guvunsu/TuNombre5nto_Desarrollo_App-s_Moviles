using Unity.VisualScripting;
using UnityEngine;

public class NormalPlatform : MonoBehaviour
{
    [SerializeField] float jumpForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 veloc = rb.linearVelocity;
                veloc.y = jumpForce;
                rb.linearVelocity = veloc;
            }
        }
    }
}
