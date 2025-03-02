using UnityEngine;

[CreateAssetMenu(fileName = "TripleShot", menuName = "WeaponStrategy/TripleShot")]
public class TripleShot : WeaponStrategy
{
    [SerializeField] float MaxSpreadAngle = 45f;
    [SerializeField] int NumberOfShots = 3;

    public override void Fire(Transform firePoint, LayerMask layer)
    {
        float totalSpread = MaxSpreadAngle * 2;

        float angleStep = totalSpread / (NumberOfShots - 1);  // Divide the total spread by the number of shots - 1

        for (int i = 0; i < NumberOfShots; i++)
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