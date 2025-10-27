using UnityEngine;

public class LavaPlatgorm : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] GameObject playerAvatar;
    [SerializeField] GameObject panelesManagersObject;

    PanelesManagers panelesManagers;

    void Awake()
    {
        if (panelesManagersObject != null)
            panelesManagers = panelesManagersObject.GetComponent<PanelesManagers>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (panelesManagers != null && playerAvatar != null)
            {
                panelesManagers.DeathPanel();
                playerAvatar.SetActive(false);
            } else
                collision.gameObject.SetActive(false);
        }
    }
}
