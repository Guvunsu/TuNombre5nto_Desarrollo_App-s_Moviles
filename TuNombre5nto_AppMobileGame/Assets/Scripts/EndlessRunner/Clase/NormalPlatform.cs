using UnityEngine;

public class NormalPlatform : MonoBehaviour
{
    [SerializeField] float jumpForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("reboto");
        if (collision.relativeVelocity.y <= 0f)
        {
            Debug.Log("reboto2");
            Rigidbody2D rb = collision.gameObject.AddComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log("reboto3");
                Vector2 veloc = rb.linearVelocity;
                veloc.y = jumpForce;
                rb.linearVelocity = veloc;
            }
        }
    }
}
