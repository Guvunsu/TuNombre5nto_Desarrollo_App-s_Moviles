using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
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
            GameObject platform = Instantiate(platformPrefab, spawnPos, Quaternion.identity);
            platformPool.Add(platform);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Platform"))
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
        //platform.transform.position = Vector3.zero;
        spawnPos = PlacePlatform(spawnPos);
        platform.transform.position = spawnPos + top.position;
        //platform.SetActive(false);
    }
}
