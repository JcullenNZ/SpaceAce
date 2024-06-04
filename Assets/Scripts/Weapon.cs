using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform shootPoint;
    public GameObject projectilePrefab;
    public float fireRate = 2f;

    public float fireSpeed = 10;
    private float nextFire = 0.0f;


    public int damage;



    public void Shoot()
    {

        if (Time.time > nextFire){
        Instantiate(projectilePrefab, shootPoint.position, transform.rotation);
        projectilePrefab.GetComponent<Projectile>().speed = fireSpeed;
        projectilePrefab.GetComponent<Projectile>().damage = damage;
        nextFire = Time.time + fireRate;
        }
        else
        {
            Debug.Log("Cannot shoot yet");
        }
    }

}
