using UnityEngine;

public class BasicPlatform : MonoBehaviour
{
    [SerializeField] float jumpForce;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("reboto");
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
