using System.Collections.Generic;
using UnityEngine;

public class MagnetCoinsManager : MonoBehaviour
{
    [Header("Configuración de Spawn")]
    [SerializeField] GameObject magnetCoinsPrefab;
    [SerializeField] Transform top;
    [SerializeField] int numberMagnetsCanSpawn = 1;
    [SerializeField] float levelWidth = 3f;
    [SerializeField] float minY = 2f;
    [SerializeField] float maxY = 1.5f;

    [Header("Referencias")]
    public MagnetCoins script_MagnetCoins;

    [Header("Lista GO")]
    [SerializeField] public List<GameObject> spawnedMagnets = new List<GameObject>();

    void Start()
    {
        Vector3 spawnPos = Vector3.zero;
        for (int i = 0; i < numberMagnetsCanSpawn; i++)
        {
            spawnPos = PlaceMagnet(spawnPos);
            Instantiate(magnetCoinsPrefab, spawnPos, Quaternion.identity);
            GameObject magnet = Instantiate(magnetCoinsPrefab, spawnPos, Quaternion.identity);
            spawnedMagnets.Add(magnet);
        }
    }
    public Vector3 PlaceMagnet(Vector3 lastSpawn)
    {
        Vector3 spawnPos = lastSpawn;
        spawnPos.y += Random.Range(minY, maxY);
        spawnPos.x = Random.Range(-levelWidth, levelWidth);
        return spawnPos;
    }
    public void RepositionMagnet(GameObject magnet)
    {
        Vector3 newPos = PlaceMagnet(Vector3.zero);
        magnet.transform.position = newPos + top.position;
    }
}
