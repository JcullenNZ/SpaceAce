using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{

    public static event Action OnEnemyDeath = delegate { };
    public int health;

    public void Die()
    {   
        OnEnemyDeath.Invoke();
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
