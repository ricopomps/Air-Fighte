using UnityEngine;

[CreateAssetMenu(fileName = "SingleShot", menuName = "WeaponStrategy/SingleShot")]
public class SingleShot : WeaponStrategy
{
    public override void Fire(Transform firePoint, LayerMask layer)
    {
        var projectile = Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation);
        projectile.transform.SetParent(firePoint);
        projectile.layer = layer;

        var projectileComponent = projectile.GetComponent<Projectile>();
        projectileComponent.SetSpeed(ProjectileSpeed);

        Destroy(projectile, ProjectileLifetime);
    }
}