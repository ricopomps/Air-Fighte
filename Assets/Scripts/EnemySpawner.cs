using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<EnemyType> EnemyTypes;
    [SerializeField] int MaxEnemies = 10;
    [SerializeField] float SpawnInterval = 2f;

    List<SplineContainer> Splines;
    EnemyFactory EnemyFactory;

    float SpawnTimer;
    int EnemiesSpawned;

    void OnValidate()
    {
        Splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
    }

    void Start() => EnemyFactory = new EnemyFactory();

    void Update()
    {
        SpawnTimer += Time.deltaTime;

        if (EnemiesSpawned < MaxEnemies && SpawnTimer >= SpawnInterval)
        {
            SpawnEnemy();
            SpawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        EnemyType enemyType = EnemyTypes[UnityEngine.Random.Range(0, EnemyTypes.Count)];
        SplineContainer spline = Splines[UnityEngine.Random.Range(0, Splines.Count)];

        EnemyFactory.CreateEnemy(enemyType, spline);

        EnemiesSpawned++;
    }
}