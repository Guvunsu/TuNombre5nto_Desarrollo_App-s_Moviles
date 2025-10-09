using UnityEngine;

public class BasicPlatform : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.gameObject.AddComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 veloc = rb.linearVelocity;
                veloc.y = jumpForce;
                rb.linearVelocity = veloc;

            }
        }
    }
}
