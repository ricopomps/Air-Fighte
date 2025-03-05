using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "Scriptable Objects/EnemyType")]
public class EnemyType : ScriptableObject
{
    public GameObject EnemyPrefab;
    public float Speed;
    public List<Item> ItemDrops;
    public float DropChance;
}
