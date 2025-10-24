using UnityEngine;
using System.Collections.Generic;

public class CoinsManager : MonoBehaviour
{
    [Header("Configuración de Spawn")]
    [SerializeField] GameObject goldCoinPrefab;
    [SerializeField] Transform top;
    [SerializeField] int numberCoinsCanSpawn = 3;
    [SerializeField] float levelWidth = 3f;
    [SerializeField] float minY = 2f;
    [SerializeField] float maxY = 1.5f;

    [Header("Referencias")]

    public DistanceJumpManager script_DistanceJumpManager;

    [Header("Lista GO")]
    [SerializeField] public List<GameObject> spawnedCoins = new List<GameObject>();

    void Start()
    {
        Vector3 spawnPos = Vector3.zero;
        for (int i = 0; i < numberCoinsCanSpawn; i++)
        {
            spawnPos = PlaceCoins(spawnPos);
            GameObject coin = Instantiate(goldCoinPrefab, spawnPos, Quaternion.identity);
            spawnedCoins.Add(coin);
        }
    }
    public Vector3 PlaceCoins(Vector3 lastSpawn)
    {
        Vector3 spawnPos = lastSpawn;
        spawnPos.y += Random.Range(minY, maxY);
        spawnPos.x = Random.Range(-levelWidth, levelWidth);
        return spawnPos;
    }
    public void RepositionCoin(GameObject coin)
    {
        Vector3 newPos = PlaceCoins(Vector3.zero);
        coin.transform.position = newPos + top.position;
    }
}
