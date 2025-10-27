using UnityEngine;

public class WaterPlatform : MonoBehaviour
{
    [Header("Timing")]
    [SerializeField] float disableColliderDelay = 0.02f;
    [SerializeField] float destroyDelay = 0.2f; 

    Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && col != null)
        {
            Invoke(nameof(DisableCollider), disableColliderDelay);
            Destroy(gameObject, destroyDelay);
        }
    }

    void DisableCollider()
    {
        if (col != null) col.enabled = false;
    }
}
