using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class Weapon : MonoBehaviour
{

    public Transform shootPoint;
    public GameObject projectilePrefab;
    public float fireRate = 2f;

    public float fireSpeed = 10;

    public bool canShoot = true;


    public int damage;

    public void Shoot()
    {   
        if (canShoot){
            InstantiateProjectile();
            StartCoroutine(ShootDelay());
        }
    }

    public void InstantiateProjectile()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, shootPoint.position, transform.rotation);
        projectileInstance.GetComponent<Projectile>().speed = fireSpeed;
        projectileInstance.GetComponent<Projectile>().damage = damage;
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;
        Debug.Log(gameObject + "Shot on cooldown");
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

}
