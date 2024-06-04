public interface IHealth
{
    void TakeDamage(int damage);
    void Die();
    void Heal(int healAmount);
    void SetHealth(int health);
    int GetHealth();
}

