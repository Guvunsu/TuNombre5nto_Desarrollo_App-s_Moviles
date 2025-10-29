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
            script_DuplicatePlayerManager.SpawnDuplicate(collision.transform);
            script_DuplicatePlayerManager.RepositionDuplicatePlayer(gameObject);
        }
    }
}
