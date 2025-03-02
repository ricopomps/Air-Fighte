using UnityEngine;

public abstract class WeaponStrategy : ScriptableObject
{
    [SerializeField] int damage = 10;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] protected float ProjectileSpeed = 10f;
    [SerializeField] protected float ProjectileLifetime = 4f;
    [SerializeField] protected GameObject ProjectilePrefab;

    public int Damage => damage;
    public float FireRate => fireRate;

    public virtual void Initialize()
    {

    }

    public abstract void Fire(Transform firePoint, LayerMask layer);
}