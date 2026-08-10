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

    }

    void CheckBoundary()// Check if the bullet is out of the screen boundary
    {
        if (transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x)
        {
            Destroy(gameObject);//if it is out of the right boundary, destroy the bullet
        }
    }
}
