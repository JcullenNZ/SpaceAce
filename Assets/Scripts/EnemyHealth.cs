using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{

    public static event Action<int> OnEnemyDeath = delegate { };
    public int health;

    public int scoreValue;

    public void Die()
    {   
        OnEnemyDeath.Invoke(scoreValue);
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
