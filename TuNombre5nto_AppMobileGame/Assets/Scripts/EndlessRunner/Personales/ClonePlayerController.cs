using UnityEngine;

public class ClonePlayerController : MonoBehaviour
{
    [Header("Referencia al jugador original")]
    public Transform originalPlayerTransform;
    public Rigidbody2D originalRb;

    Rigidbody2D rb;

    [Header("Opciones")]
    [SerializeField] float followSmooth = 10f; // suavizado para la posición horizontal
    [SerializeField] float maxXOffset = 0f; // si quieres que el clon tenga un offset opcional

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (originalPlayerTransform == null) return;

        // Seguir horizontalmente con suavizado (no controlar input propio)
        Vector2 targetPos = new Vector2(originalPlayerTransform.position.x + maxXOffset, transform.position.y);
        Vector2 newPos = Vector2.Lerp(transform.position, targetPos, followSmooth * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        // Copiar velocidad vertical para que salte/caiga igual
        if (originalRb != null && rb != null)
        {
            Vector2 v = rb.linearVelocity;
            v.y = originalRb.linearVelocity.y;
            rb.linearVelocity = v;
        }
    }
}
