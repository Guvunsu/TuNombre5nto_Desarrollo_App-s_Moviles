using System.Collections.Generic;
using UnityEngine;

public class DuplicatePlayerManager : MonoBehaviour
{
    [Header("Configuración de Spawn")]
    [SerializeField] GameObject duplicatePlayerPrefab;
    [SerializeField] Transform top;
    [SerializeField] int numberDuplicatePlayerCanSpawn = 1;
    [SerializeField] float levelWidth = 3f;
    [SerializeField] float minY = 2f;
    [SerializeField] float maxY = 1.5f;

    [Header("Referencias")]
    public DuplicatePlayer script_DuplicatePlayer;

    [Header("Lista GO")]
    [SerializeField] public List<GameObject> spawnedDuplicatePlayer = new List<GameObject>();

    void Start()
    {
        Vector3 spawnPos = Vector3.zero;
        for (int i = 0; i < numberDuplicatePlayerCanSpawn; i++)
        {
            spawnPos = PlaceDuplicatePlayer(spawnPos);
            // mantengo tu doble Instantiate como estaba
            Instantiate(duplicatePlayerPrefab, spawnPos, Quaternion.identity);
            GameObject duplicate = Instantiate(duplicatePlayerPrefab, spawnPos, Quaternion.identity);
            spawnedDuplicatePlayer.Add(duplicate);
        }
    }

    public Vector3 PlaceDuplicatePlayer(Vector3 lastSpawn)
    {
        Vector3 spawnPos = lastSpawn;
        spawnPos.y += Random.Range(minY, maxY);
        spawnPos.x = Random.Range(-levelWidth, levelWidth);
        return spawnPos;
    }

    public void RepositionDuplicatePlayer(GameObject duplicate)
    {
        Vector3 newPos = PlaceDuplicatePlayer(Vector3.zero);
        duplicate.transform.position = newPos + top.position;
    }

    // NUEVO: Instancia un clon en tiempo de ejecución y lo prepara para seguir al jugador original
    // originalPlayerTransform: transform del jugador que tomó el power-up
    public void SpawnDuplicate(Transform originalPlayerTransform)
    {
        if (duplicatePlayerPrefab == null || originalPlayerTransform == null) return;

        // spawn cerca del original (o donde quieras); aquí lo spawnamos con un offset en X y Y
        Vector3 spawnPos = originalPlayerTransform.position + new Vector3(1.0f, 0.0f, 0f);
        GameObject clone = Instantiate(duplicatePlayerPrefab, spawnPos, Quaternion.identity);

        // Si el prefab tiene ClonePlayerController lo configuramos para seguir al original
        ClonePlayerController cloneCtrl = clone.GetComponent<ClonePlayerController>();
        Rigidbody2D originalRb = originalPlayerTransform.GetComponent<Rigidbody2D>();
        if (cloneCtrl != null)
        {
            cloneCtrl.originalPlayerTransform = originalPlayerTransform;
            cloneCtrl.originalRb = originalRb;
        }

        // Añadir a la lista (si quieres rastrearlos)
        spawnedDuplicatePlayer.Add(clone);

        // Opcional: destruir el clon después de cierto tiempo si deseas (ejemplo 10s)
        Destroy(clone, 10f);
    }
}
