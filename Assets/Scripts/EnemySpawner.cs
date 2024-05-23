using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // List of different enemy prefabs
    public float spawnInterval = 0.3f;
    private Player player;

    private float nextSpawnTime = 0f;
    private List<GameObject> spawnedEnemies = new List<GameObject>(); // List to keep track of spawned enemies
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogWarning("No player object found.");
        }
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Count == 0)
        {
            Debug.LogWarning("No enemy prefabs assigned to the spawner.");
            return;
        }

        // Select a random enemy prefab from the list TODO: add logic to decide what enemy should be spawned
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        // Generate a random position outside the screen bounds
        Vector2 spawnPosition = GetRandomSpawnPosition();

        // Instantiate the enemy and add it to the list of spawned enemies
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        spawnedEnemies.Add(spawnedEnemy);
    }

    Vector2 GetRandomSpawnPosition()
    {
        Vector2 spawnPosition = Vector2.zero;

        // Determine the screen bounds in world space
        float screenAspect = mainCamera.aspect;
        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * screenAspect;

        // Randomly choose a point on the bounding box around the screen
        int side = Random.Range(0, 4);
        switch (side)
        {
            case 0: // Left
                spawnPosition = new Vector2(-cameraWidth / 2, Random.Range(-cameraHeight / 2, cameraHeight / 2));
                break;
            case 1: // Right
                spawnPosition = new Vector2(cameraWidth / 2, Random.Range(-cameraHeight / 2, cameraHeight / 2));
                break;
            case 2: // Top
                spawnPosition = new Vector2(Random.Range(-cameraWidth / 2, cameraWidth / 2), cameraHeight / 2);
                break;
            case 3: // Bottom
                spawnPosition = new Vector2(Random.Range(-cameraWidth / 2, cameraWidth / 2), -cameraHeight / 2);
                break;
        }

        return spawnPosition;
    }

    public void PerformActionOnAllEnemies()
    {
        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null)
            {
                
            }
        }
    }
}
