using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Weapon weapon;
    public float speed;
    public float rotationSpeed;

    public Transform player;


    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
      Vector3 direction = (player.position - transform.position).normalized;
      transform.position += direction * speed * Time.deltaTime;
    
    transform.up = direction;
        /*float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

      Quaternion toRotation = Quaternion.Euler(0,0,angle -90);
      transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);     
       */
        weapon.Shoot();
      
    }
}
