using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;

    [SerializeField] int numOfPlatform = 200;
    [SerializeField] float levelWidth = 3f;
    [SerializeField] float minY = 2f;
    [SerializeField] float maxY = 1.5f;

    void Start()
    {
        Vector3 spawnPos = new Vector3();
        for (int i = 0; i < numOfPlatform; i++)
        {
            spawnPos.y += Random.Range(minY, maxY);
            spawnPos.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPos, Quaternion.identity);
        }
    }
}
