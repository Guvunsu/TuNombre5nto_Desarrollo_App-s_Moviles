using UnityEngine;

public class DuplicatePlayer : MonoBehaviour
{
    public DuplicatePlayerManager script_DuplicatePlayerManager;

    void Start()
    {
        if (script_DuplicatePlayerManager == null)
            script_DuplicatePlayerManager = FindAnyObjectByType<DuplicatePlayerManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && script_DuplicatePlayerManager != null)
        {
            // Pedimos al manager que genere un clon que siga al jugador
            script_DuplicatePlayerManager.SpawnDuplicate(collision.transform);

            // Reposicionar o destruir el power-up para reciclarlo
            script_DuplicatePlayerManager.RepositionDuplicatePlayer(gameObject);
        }
    }
}
