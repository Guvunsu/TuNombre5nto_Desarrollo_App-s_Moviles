using UnityEngine;
using System;

public class DeadMomentWhenYouFall : MonoBehaviour
{
    [SerializeField] GameObject playerAvatar;
    public PanelesManagers script_PanelesManagers;

    // NUEVO: evento que se dispara cuando el jugador muere
    public event Action OnPlayerDead;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DeadPlayer();
        }
    }

    public void DeadPlayer()
    {
        script_PanelesManagers.DeathPanel();
        playerAvatar.SetActive(false);

        // Disparar evento para otros scripts (como ConfinerMovement)
        OnPlayerDead?.Invoke();
    }
}
