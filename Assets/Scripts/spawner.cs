using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float spawnInterval = 1f;
    public float minX = -2f;
    public float maxX = 2f;

    private float timer;
    public int score = 0;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // Calculate a random x position relative to the spawner object's position
            float randomX = transform.position.x + Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

            // Determine the "Enemy Type" based on the score and randomness
            char enemyType = GetRandomEnemyType();

            // Create a new enemy GameObject
            GameObject enemy = Instantiate(spawnPrefab, spawnPosition, Quaternion.identity);

            // Set the "Enemy Type" on the spawned enemy
            enemy.GetComponent<EnemyMovement>().enemyType = enemyType;

            // Reset the timer
            timer = spawnInterval;
        }
    }

    private char GetRandomEnemyType()
    {
        float randomValue = Random.value;

        if (score <= 100)
        {
            if (randomValue <= 0.8f)
                return 'a';
            else
                return 'b';
        }
        else if (score <= 300)
        {
            if (randomValue <= 0.6f)
                return 'a';
            else if (randomValue <= 0.9f)
                return 'b';
            else
                return 'c';
        }
        else
        {
            if (randomValue <= 0.2f)
                return 'a';
            else if (randomValue <= 0.6f)
                return 'b';
            else
                return 'c';
        }
    }
}
