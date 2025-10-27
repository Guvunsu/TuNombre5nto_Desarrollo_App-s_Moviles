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
        if (collision.CompareTag("Player") || collision.transform.parent.CompareTag("Player"))
        {
            Debug.Log("detecto player?");
            script_CoinsManager.script_ScoreCoins.AddCoinScore();
            script_CoinsManager.RepositionCoin(gameObject);
        }

    }
}