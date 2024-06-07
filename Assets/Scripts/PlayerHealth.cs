using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public static event Action OnPlayerDeath;
    public static PlayerHealth Instance { get; private set; }

    public int health;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void Die()
    {
        Debug.Log("Player has died");
        OnPlayerDeath?.Invoke();
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
        Debug.Log("Player has taken damage");
        Debug.Log("Player health: " + health);
        if (health <= 0)
        {
            Die();
        }
    }


}
