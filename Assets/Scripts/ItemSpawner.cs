using System.Collections.Generic;
using MEC;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Item[] ItemPrefabs;
    [SerializeField] float SpawnInterval = 3f;
    [SerializeField] float SpawnRadius = 3f;

    CoroutineHandle SpawnCoroutine;

    void Start() => SpawnCoroutine = Timing.RunCoroutine(SpawnItems());

    IEnumerator<float> SpawnItems()
    {
        while (true)
        {
            yield return Timing.WaitForSeconds(SpawnInterval);
            var item = Instantiate(ItemPrefabs[Random.Range(0, ItemPrefabs.Length)]);
            item.transform.position = (transform.position + Random.insideUnitSphere * SpawnRadius).With(y: transform.position.y, z: 0);
        }
    }
}
