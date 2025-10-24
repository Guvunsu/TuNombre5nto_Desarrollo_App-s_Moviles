using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinsManager script_CoinsManager;

    void Start()
    {
        script_CoinsManager = FindAnyObjectByType<CoinsManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            script_CoinsManager.script_DistanceJumpManager.AddCoinScore();
            script_CoinsManager.RepositionCoin(gameObject);
        }
    }
}
