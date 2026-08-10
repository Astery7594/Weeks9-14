using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction = Vector2.right; // Default direction is to the right
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet in the specified direction (right)
        Vector3 movement = new Vector3(direction.x, direction.y,0f) * speed * Time.deltaTime;
        transform.position += movement;
        CheckBoundary();
        CheckEnemyHit();

    }

    void CheckBoundary()// Check if the bullet is out of the screen boundary
    {
        if (transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x)
        {
            Destroy(gameObject);//if it is out of the right boundary, destroy the bullet
        }
    }

    void CheckEnemyHit()// Check if the bullet is close enough to the enemy then destroy it
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");// Find all enemy objects
        for (int i = 0; i < enemies.Length; i++) 
        { 
            GameObject enemyObject = enemies[i];// Get the enemy object
            float distance = Vector2.Distance(transform.position, enemyObject.transform.position);// Calculate the distance between the bullet and the enemy
            if( distance <= 0.5f)// If the distance is less than or equal to 0.5 units
            {
                Destroy(enemyObject);// Destroy the enemy
                Destroy(gameObject);// Destroy the bullet
                return; // Exit the loop after destroying the enemy and bullet
            }

        }
    }
}
