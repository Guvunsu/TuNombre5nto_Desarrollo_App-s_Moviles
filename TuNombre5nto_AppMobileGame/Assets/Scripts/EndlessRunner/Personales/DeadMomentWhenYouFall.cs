using UnityEngine;

public class DeadMomentWhenYouFall : MonoBehaviour
{
    [SerializeField] GameObject playerAvatar;
    public PanelesManagers script_PanelesManagers;

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
    }
}
