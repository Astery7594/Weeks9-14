using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPerfab; // The enemy prefab to instantiate
    public int MaxEnemyCount = 3; // The maximum number of enemies to spawn
    public Sprite[] enemySprites; // Array of enemy sprites
    public float spawnInterval = 2f; // The interval between enemy spawns
    
    private List<GameObject> spawnedEnemies = new List<GameObject>(); // List to keep track of spawned enemies
    private float spawnTimer = 0f; // Timer to track the spawn interval

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CleanupDestoryedEnemies();// Clean up any destroyed enemies from the list first
        if(spawnedEnemies.Count < MaxEnemyCount) // Check if the number of spawned enemies is less than the maximum allowed
        {
            spawnTimer += Time.deltaTime; // Increment the spawn timer by the time elapsed since the last frame
            if (spawnTimer >= spawnInterval) // Check if the spawn timer has reached or exceeded the spawn interval
            {
                SpawnEnemy(); // Spawn a new enemy
                spawnTimer = 0f; // Reset the spawn timer
            }
        }
        else
        {
            spawnTimer = 0f; // Reset the spawn timer if the maximum number of enemies has been reached
        }
    }

    void SpawnEnemy()
    { 
        Vector2 spawnPos = GetRandomSpawnPosition(); // Get a random spawn position
        GameObject newEnemy = Instantiate(enemyPerfab, spawnPos, Quaternion.identity); // Instantiate the enemy prefab at the spawn position
        spawnedEnemies.Add(newEnemy);
        EnemyMovement enemySprite = newEnemy.GetComponent<EnemyMovement>(); // Get the EnemyMovement component from the instantiated enemy
        if (enemySprite != null && enemySprites.Length >0)
        {
            Sprite randomSprite = GetRandomEnemySprite(); // Get a random enemy sprite
            enemySprite.ChangeSprite(randomSprite); // Change the enemy sprite to the randomly selected sprite
        }
    }

    Vector2 GetRandomSpawnPosition()
    {
        // Spawn just outside the right edge of the screen
        float x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x + 0.5f;
        // Spawn at a random y position within the screen bounds
        float y = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y + 0.5f, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - 0.5f);
        return new Vector2(x, y); // Return the random spawn position
    }
    Sprite GetRandomEnemySprite()
    {
        // Check if the enemySprites array is empty
        if (enemySprites.Length == 0)
        {
            return null; // Return null if there are no sprites in the array
        }
        int randomIndex = Random.Range(0, enemySprites.Length); // Get a random index from the sprite array
        return enemySprites[randomIndex]; // Return the randomly selected sprite
    }
    void CleanupDestoryedEnemies()
    {
        // Remove any destroyed enemies from the list
        for (int i = spawnedEnemies.Count - 1; i >= 0; i--)
        {
            if (spawnedEnemies[i] == null)
            {
                spawnedEnemies.RemoveAt(i); // Remove the destroyed enemy from the list
            }
        }
    }

}
