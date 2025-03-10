using UnityEngine;

public abstract class Plane : MonoBehaviour
{
    [SerializeField] int MaxHealth;
    int Health;

    protected virtual void Awake() => Health = MaxHealth;

    public virtual void TakeDamage(int amount)
    {
        if (Health <= 0) return;

        Health -= amount;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public float GetHealthNormalized() => Health / (float)MaxHealth;

    protected abstract void Die();
}
