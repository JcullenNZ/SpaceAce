using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{

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
        gameObject.GetComponent<Transform>().position = new Vector3(0, 0, 0);
        SetHealth(10);
        //GameManager.Instance.EndGame(200, PlayerPrefs.GetString("PlayerName"));
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
        if (health <= 0)
        {
            Die();
        }
    }


}
