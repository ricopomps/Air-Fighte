using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponStrategy WeaponStrategy;
    [SerializeField] protected Transform FirePoint;
    [SerializeField, Layer] protected int Layer;

    void OnValidate() => Layer = gameObject.layer;

    public void SetWeaponStrategy(WeaponStrategy strategy)
    {
        WeaponStrategy = strategy;
        WeaponStrategy.Initialize();
    }
}
