using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class Weapon : MonoBehaviour
{

    public Transform shootPoint;
    public GameObject projectilePrefab;
    public float fireRate = 2f;

    public float fireSpeed = 10;
    private float nextFire = 0.0f;

    public bool canShoot = true;


    public int damage;

    public void Shoot()
    {   
        if (canShoot){
            InstantiateProjectile();
            StartCoroutine(ShootDelay());
        }
        else
        {
            Debug.Log("Cannot shoot yet");
        }
    }

    public void InstantiateProjectile()
    {
        Instantiate(projectilePrefab, shootPoint.position, transform.rotation);
        projectilePrefab.GetComponent<Projectile>().speed = fireSpeed;
        projectilePrefab.GetComponent<Projectile>().damage = damage;
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;
        Debug.Log(gameObject + "Shot on cooldown");
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

}