using UnityEngine;
using UnityEngine.Events;

public class ShootModule2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Event that is triggered when the player shoots
    public UnityEvent OnAttack;

    public void Shoot()
    {
        // Trigger the OnAttack event
        OnAttack.Invoke();
    }
}
