using UnityEngine;
using UnityEngine.Events;

public class Enemy : Plane
{
    [SerializeField] GameObject ExplosionPrefab;
    protected override void Die()
    {
        GameManager.Instance.AddScore(10);
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        OnSystemDestroyed?.Invoke();
        Destroy(gameObject);
    }

    public UnityEvent OnSystemDestroyed;
}
