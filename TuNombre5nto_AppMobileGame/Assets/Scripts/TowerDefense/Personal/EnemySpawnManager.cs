using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Prefabs de Enemigos")]
    public GameObject[] enemyPrefabs;

    [Header("Spawn")]
    public float spawnRate = 2f;

    [Header("PointA y PointB en cada lane")]
    public Transform[] pointA_List;
    public Transform[] pointB_List;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0)
        {
            Debug.LogError("No hay prefabs asignados en enemyPrefabs[]");
            return;
        }
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        int lane = Random.Range(0, pointA_List.Length);
        GameObject e = Instantiate(enemyPrefabs[enemyIndex], pointA_List[lane].position, Quaternion.identity);

        // Asignar recorrido (SetPath)
        EnemyBase enemy = e.GetComponent<EnemyBase>();
        enemy.SetPath(pointA_List[lane], pointB_List[lane]);
    }
}
