using System.Collections.Generic;
using MEC;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Item[] ItemPrefabs;
    [SerializeField] float SpawnInterval = 3f;
    [SerializeField] float SpawnRadius = 3f;

    CoroutineHandle SpawnCoroutine;
    ItemFactory ItemFactory;

    void Start()
    {
        ItemFactory = new ItemFactory();
        SpawnCoroutine = Timing.RunCoroutine(SpawnItems());
    }

    IEnumerator<float> SpawnItems()
    {
        while (true)
        {
            yield return Timing.WaitForSeconds(SpawnInterval);

            Item itemPrefab = ItemPrefabs[Random.Range(0, ItemPrefabs.Length)];
            Vector3 spawnPosition = (transform.position + Random.insideUnitSphere * SpawnRadius).With(y: transform.position.y, z: 0);

            ItemFactory.CreateItem(itemPrefab, spawnPosition);
        }
    }
}
