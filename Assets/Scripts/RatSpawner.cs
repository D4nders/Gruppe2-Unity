using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnDelay;
    public float moveDuration;
    public float moveSpeed;
    public float repeatInterval;

    private void Start()
    {
        StartCoroutine(SpawnRatsRepeatedly());
    }

    private IEnumerator SpawnRatsRepeatedly()
    {
        while (true)
        {
            int numberOfRatsToSpawn = Random.Range(3, 9);
            StartCoroutine(SpawnPrefabs(numberOfRatsToSpawn));

            yield return new WaitForSeconds(repeatInterval);
        }
    }

    private IEnumerator SpawnPrefabs(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

            // Get animator component from the spawned rat
            Animator ratAnimator = spawnedPrefab.GetComponent<Animator>();
            if (ratAnimator != null)
            {
                ratAnimator.SetFloat("X", 0f); // Face down (south)
                ratAnimator.SetFloat("Y", -1f);
            }
            else
            {
                Debug.LogWarning("Animator not found on rat prefab!");
            }

            StartCoroutine(MoveAndDestroy(spawnedPrefab));

            float randomDelay = Random.Range(1f, 4.1f);
            yield return new WaitForSeconds(randomDelay);
        }
    }

    private IEnumerator MoveAndDestroy(GameObject obj)
    {
        float timeElapsed = 0f;
        while (timeElapsed < moveDuration)
        {
            obj.transform.position += moveSpeed * Time.deltaTime * Vector3.down;
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(obj);
    }
}
