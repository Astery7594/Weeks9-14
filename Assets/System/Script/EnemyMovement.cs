using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the enemy movement
    public Vector2 direction = Vector2.left; // Default direction is to the left

    private SpriteRenderer spriteRenderer; // use to change enemy sprite
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(direction.x, direction.y, 0f) * speed * Time.deltaTime;
        transform.position += movement;//move the enemy in the specified direction (left)
        CheckBoundary();
    }

    void CheckBoundary()
    {
        // Check if the enemy is out of the screen boundary
        if (transform.position.x <= Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x)
        {
            Destroy(gameObject);//if it is out of the left boundary, destroy the enemy
        }
    }

    public void ChangeSprite(Sprite newSprite)//use in EnemySpawner to change the sprite of the enemy when it is spawned
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = newSprite; // Change the sprite of the enemy
        }
    }
}
