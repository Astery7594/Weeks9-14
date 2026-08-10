using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to instantiate
    public GameObject bulletPrefab2;// The second kind of bullet prefab to instantiate
    public Transform firePoint; // The point from which the bullet will be fired
    public Transform firePoint2;// The point from which the second kind of bullet will be fired
    public float bulletSpeed = 10f; // The speed at which the bullet will move
    public float bulletSpeed2 = 15f;// The speed second kinds of bullet will move
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet()
    {
        //spawn a bullet at the fire point position with no rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        // Get the BulletMovement component from the instantiated bullet
        BulletMovement bulletMovement = bullet.GetComponent<BulletMovement>();
        if(bulletMovement != null)
        {
            // Set the speed of the bullet
            bulletMovement.speed = bulletSpeed;
        }
    }

    public void FireMoreBullet()// Fire a second kind of bullet with different speed
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        // Get the BulletMovement component from the instantiated bullet
        BulletMovement bulletMovement = bullet.GetComponent<BulletMovement>();
        if (bulletMovement != null)
        {
            // Set the speed of the bullet
            bulletMovement.speed = bulletSpeed;
        }
        GameObject bullet2 = Instantiate(bulletPrefab2, firePoint2.position, Quaternion.identity);
        // Get the BulletMovement component from another bullet
        BulletMovement bulletMovement2 = bullet.GetComponent<BulletMovement>();
        if(bulletMovement != null)
        {
            bulletMovement.speed = bulletSpeed2;
        }
    }
}
