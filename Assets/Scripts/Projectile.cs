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

   /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    } */  
}
