using UnityEngine;

public class Item : MonoBehaviour
{
    private float timer;//set a timer
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        //Debug.Log(timer);
        

        if (timer >= 2f)
        {
            //change position of the item to a random position on the screen during some time
            Vector2 p = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height)));

            transform.position = p;
            timer = 0f;
        }
        CollisionWithPlayer();
    }
    void CollisionWithPlayer()
    {
        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 1f)
        {
            //if the player is close enough to the item, destroy the item
            Destroy(gameObject);
        }
    }
}
