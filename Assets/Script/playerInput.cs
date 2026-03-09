using UnityEngine;
using UnityEngine.InputSystem;

public class playerInput : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 movement;
    public AudioSource soundEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ansform.position += (Vector3)movement*speed*Time.deltaTime;
        transform.position = movement;

    }

    public void Onmove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack" + context.phase);
        if(context.performed == true)
        {
            soundEffect.Play();
        }

    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        movement = Camera.main.ScreenToViewportPoint(context.ReadValue<Vector2>());
    }
}
