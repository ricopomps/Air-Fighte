using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] GameObject MuzzlePrefab;
    [SerializeField] GameObject HitPrefab;

    Transform Parent;

    public void SetSpeed(float speed) => Speed = speed;
    public void SetParent(Transform parent) => Parent = parent;

    public Action Callback;

    void Start()
    {
        if (MuzzlePrefab is not null)
        {
            var muzzleVFX = Instantiate(MuzzlePrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
            muzzleVFX.transform.SetParent(Parent);

            DestroyParticleSystem(muzzleVFX);
        }
    }

    void DestroyParticleSystem(GameObject vfx)
    {
        var ps = vfx.GetComponent<ParticleSystem>();

        if (ps is null)
        {
            ps = vfx.GetComponentInChildren<ParticleSystem>();
        }

        Destroy(vfx, ps.main.duration);
    }

    void Update()
    {
        transform.SetParent(null);
        transform.position += transform.forward * (Speed * Time.deltaTime);

        Callback?.Invoke();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (HitPrefab is not null)
        {
            ContactPoint contact = collision.contacts[0];
            var hitVFX = Instantiate(HitPrefab, contact.point, Quaternion.identity);

            DestroyParticleSystem(hitVFX);
        }

        var plane = collision.gameObject.GetComponent<Plane>();
        if (plane != null)
        {
            plane.TakeDamage(10);
        }

        Destroy(gameObject);
    }
}
