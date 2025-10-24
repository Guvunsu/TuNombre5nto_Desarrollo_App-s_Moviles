using UnityEngine;

public class MagnetCoins : MonoBehaviour
{
    // le puse trigger para la colision del jugador con el powerup

    void Start()
    {
      
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        
        }
    }
}
