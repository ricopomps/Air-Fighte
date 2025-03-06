using UnityEngine;

[CreateAssetMenu(fileName = "PlayerGun", menuName = "WeaponStrategy/PlayerGun")]
public class PlayerGun : WeaponStrategy
{
    [SerializeField] float MaxSpreadAngle = 45f;

    public override void Fire(Transform firePoint, LayerMask layer)
    {
        float totalSpread = MaxSpreadAngle * 2;
        Player player = PlayerTracker.Instance.GetTarget().GetComponent<Player>();

        int shotCount = player.GetShots();
        float angleStep = shotCount > 1 ? totalSpread / (shotCount - 1) : 0;

        for (int i = 0; i < shotCount; i++)
        {
            var projectile = Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);

            float angle = shotCount > 1 ? -MaxSpreadAngle + (i * angleStep) : 0f;
            projectile.transform.Rotate(0f, angle, 0f);
            projectile.layer = layer;

            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(ProjectileSpeed);

            Destroy(projectile, ProjectileLifetime);
        }
    }
}
