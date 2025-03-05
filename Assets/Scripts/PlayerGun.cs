using UnityEngine;

[CreateAssetMenu(fileName = "PlayerGun", menuName = "WeaponStrategy/PlayerGun")]
public class PlayerGun : WeaponStrategy
{
    [SerializeField] float MaxSpreadAngle = 45f;

    public override void Fire(Transform firePoint, LayerMask layer)
    {
        float totalSpread = MaxSpreadAngle * 2;
        Player player = PlayerTracker.Instance.GetTarget().GetComponent<Player>();

        float angleStep = totalSpread / (player.GetShots() - 1);  // Divide the total spread by the number of shots - 1

        for (int i = 0; i < player.GetShots(); i++)
        {
            var projectile = Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);

            // Calculate the angle for this shot
            float angle = -MaxSpreadAngle + (i * angleStep); // Distribute evenly across the range

            // Rotate the projectile
            projectile.transform.Rotate(0f, angle, 0f);  // Adjust rotation based on the calculated angle
            projectile.layer = layer;

            // Set the projectile speed
            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(ProjectileSpeed);

            // Destroy the projectile after its lifetime expires
            Destroy(projectile, ProjectileLifetime);
        }
    }
}