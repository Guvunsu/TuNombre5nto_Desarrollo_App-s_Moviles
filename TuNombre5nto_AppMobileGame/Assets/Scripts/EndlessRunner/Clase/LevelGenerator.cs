using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [Header("Prefabs de Plataformas")]
    [SerializeField] GameObject platformPrefab;  
    [SerializeField] GameObject icePlatformPrefab;    
    [SerializeField] GameObject lavaPlatformPrefab;   

    [Header("Configuración de Nivel")]
    [SerializeField] Transform top;
    [SerializeField] List<GameObject> platformPool;

    [SerializeField] int numOfPlatform = 200;
    [SerializeField] float levelWidth = 3f;
    [SerializeField] float minY = 2f;
    [SerializeField] float maxY = 1.5f;

    void Start()
    {
        Vector3 spawnPos = new Vector3();

        for (int i = 0; i < numOfPlatform; i++)
        {
            spawnPos = PlacePlatform(spawnPos);
            GameObject platformToSpawn = ChoosePlatformType();
            Instantiate(platformToSpawn, spawnPos, Quaternion.identity);
            GameObject platform = Instantiate(platformToSpawn, spawnPos, Quaternion.identity);
            platformPool.Add(platform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" ||
            collision.gameObject.tag == "IcePlatform" ||
            collision.gameObject.tag == "LavaPlatform")
        {
            DestroyPlatform(collision.gameObject);
        }
    }

    Vector3 PlacePlatform(Vector3 spawnPos)
    {
        spawnPos.y += Random.Range(minY, maxY);
        spawnPos.x = Random.Range(-levelWidth, levelWidth);
        return spawnPos;
    }

    void DestroyPlatform(GameObject platform)
    {
        Vector3 spawnPos = new Vector3();
        spawnPos = PlacePlatform(spawnPos);
        platform.transform.position = spawnPos + top.position;
    }

    GameObject ChoosePlatformType()
    {
        int randomType = Random.Range(0, 3); // 0 = normal, 1 = hielo, 2 = lava
        switch (randomType)
        {
            case 1:
                return icePlatformPrefab != null ? icePlatformPrefab : platformPrefab;
            case 2:
                return lavaPlatformPrefab != null ? lavaPlatformPrefab : platformPrefab;
            default:
                return platformPrefab;
        }
    }
}
