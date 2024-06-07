using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]public float speed;
    [HideInInspector]public int damage;

    public int timeToLive = 1;
void Start()
    {
        Destroy(gameObject, timeToLive);
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);


    }

   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && gameObject.CompareTag("EnemyProjectile"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("PlayerProjectile"))
        {
            return;
        }
       else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
