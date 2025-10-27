using UnityEngine;

public class MagnetCoins : MonoBehaviour
{
    public MagnetCoinsManager script_MagnetCoinsManager;

    void Start()
    {
        if (script_MagnetCoinsManager == null)
            script_MagnetCoinsManager = FindAnyObjectByType<MagnetCoinsManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MagnetEffect magnet = collision.GetComponent<MagnetEffect>();
            if (magnet != null)
                magnet.ActivateMagnet();

            if (script_MagnetCoinsManager != null)
                script_MagnetCoinsManager.RepositionMagnet(gameObject);
            else
                Destroy(gameObject);
        }
    }
}
