using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTrackingShot", menuName = "WeaponStrategy/PlayerTrackingShot")]
public class PlayerTrackingShot : WeaponStrategy
{
    [SerializeField] float TrackingSpeed = 1f;

    public override void Fire(Transform firePoint, LayerMask layer)
    {
        var projectile = Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation);
        projectile.transform.SetParent(firePoint);
        projectile.layer = layer;

        var projectileComponent = projectile.GetComponent<Projectile>();
        projectileComponent.SetSpeed(ProjectileSpeed);
        projectile.GetComponent<Projectile>().Callback = () =>
        {
            var target = PlayerTracker.Instance.GetTarget();
            Vector3 direction = (target.transform.position - projectile.transform.position).With(z: firePoint.position.z).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.forward);
            projectile.transform.rotation = Quaternion.Slerp(projectile.transform.rotation, rotation, TrackingSpeed * Time.deltaTime);
        };

        Destroy(projectile, ProjectileLifetime);
    }
}