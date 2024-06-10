using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public static event Action OnPlayerDeath;
    public static PlayerHealth Instance { get; private set; }

    public Slider healthBar;
    public GameObject deathEffect;

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
        AudioManager.Instance.PlaySFX(AudioManager.Instance.gameOver);	
        OnPlayerDeath?.Invoke();
    }

    public int GetHealth()
    {
        return health;
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        healthBar.value = health;
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
        healthBar.maxValue = health;
    }

    public void TakeDamage(int damage)
    {
        
        health -= damage;
        healthBar.value = health;
        if (health <=2 )
        {
            healthBar.GetComponentInChildren<Image>().color = Color.red;
        }
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Die();
        }
    }


}
