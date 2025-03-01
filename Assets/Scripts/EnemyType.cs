using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "Scriptable Objects/EnemyType")]
public class EnemyType : ScriptableObject
{
    public GameObject EnemyPrefab;
    public GameObject WeaponPrefab;
    public float Speed;
}
