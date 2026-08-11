using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // The speed at which the player moves
    public ShootModule ShootModule; // Reference to the ShootModule component
    public ShootModule2 ShootModule2;//for the second shoot module

    private Vector2 moveInput; // The input vector for movement
    Item item; // Reference to the Item component
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShootModule.enabled = true; // Enable the ShootModule component
        ShootModule2.enabled = false;// Disable the ShootModule2 component
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement vector based on input and speed
        Vector3 movement = new Vector3(moveInput.x, moveInput.y,0f) * moveSpeed * Time.deltaTime;
        transform.position += movement; // Move the player by updating its position
        CheckItemsCollision(); // Check for collision with items
    }

    //use input system to get the move input from the player
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            if(ShootModule.enabled)
            {
                ShootModule.Shoot(); // Call the Shoot method from the ShootModule
            }
            else if(ShootModule2.enabled)
            {
                ShootModule2.Shoot(); // Call the Shoot method from the ShootModule2
            }
            
        }
    }
    public void CheckItemsCollision()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");// Find all item objects in the scene
        for (int i = 0; i < items.Length; i++)
        {
            // Get the item object and calculate the distance between the player and the item
            GameObject itemObject = items[i];
            float distance = Vector2.Distance(transform.position, itemObject.transform.position);
            if (distance <= 1f)
            {
                // If the distance is less than or equal to 1 units, destroy the item and switch shooting modules
                ShootModule.enabled = false;
                ShootModule2.enabled = true;
            }
        }
    }

}
