using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{

    public int health;

    public void Die()
    {
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy has taken damage");
        Debug.Log("Enemy health: " + health); 
        if (health <= 0)
        {
            Die();
        }
    }

}
