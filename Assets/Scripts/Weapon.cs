using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform shootPoint;
    public GameObject projectilePrefab;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public int damage;



    public void Shoot()
    {
        if (Time.time > nextFire){
        Instantiate(projectilePrefab, shootPoint.position, transform.rotation);
        projectilePrefab.GetComponent<Projectile>().damage = damage;
        nextFire = Time.time + fireRate;}
        else
        {
            Debug.Log("Cannot shoot yet");
        }
    }

}
