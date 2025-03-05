using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Enemy : Plane
{
    [SerializeField] GameObject ExplosionPrefab;
    private List<Item> ItemDrops;
    private float DropChance = 1.0f;
    ItemFactory ItemFactory;

    void Start()
    {
        ItemFactory = new ItemFactory();
    }

    protected override void Die()
    {
        GameManager.Instance.AddScore(10);
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);

        DropItems();

        OnSystemDestroyed?.Invoke();
        Destroy(gameObject);
    }

    private void DropItems()
    {
        if (ItemDrops != null && ItemDrops.Count > 0 && Random.value <= DropChance)
        {
            Item itemPrefab = ItemDrops[Random.Range(0, ItemDrops.Count)];

            ItemFactory.CreateItem(itemPrefab, transform.position);
        }
    }

    public UnityEvent OnSystemDestroyed;

    public void SetItemDrops(List<Item> items)
    {
        ItemDrops = items;
    }

    public void SetDropChance(float chance)
    {
        DropChance = Mathf.Clamp01(chance);
    }
}
