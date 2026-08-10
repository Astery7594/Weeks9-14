using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the player moves
    public ShootModule ShootModule; // Reference to the ShootModule component

    private Vector2 moveInput; // The input vector for movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement vector based on input and speed
        Vector3 movement = new Vector3(moveInput.x, moveInput.y,0f) * moveSpeed * Time.deltaTime;
        transform.position += movement; // Move the player by updating its position
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
            ShootModule.Shoot(); // Call the Shoot method from the ShootModule
            
        }
    }

}
