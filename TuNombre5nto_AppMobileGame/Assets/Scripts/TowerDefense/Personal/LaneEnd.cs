using UnityEngine;

public class LaneEnd : MonoBehaviour
{
    public LifeSystemLane lane;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            lane.DamageLane(1);
            Destroy(other.gameObject);
        }
    }
}