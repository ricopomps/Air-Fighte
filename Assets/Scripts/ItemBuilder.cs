using UnityEngine;

public class ItemBuilder
{
    private GameObject ItemPrefab;
    private Vector3 Position;

    public ItemBuilder SetBasePrefab(GameObject prefab)
    {
        ItemPrefab = prefab;
        return this;
    }

    public ItemBuilder SetPosition(Vector3 position)
    {
        Position = position;
        return this;
    }

    public GameObject Build()
    {
        if (ItemPrefab == null)
        {
            Debug.LogError("ItemBuilder: ItemPrefab is null!");
            return null;
        }

        GameObject instance = GameObject.Instantiate(ItemPrefab);
        instance.transform.position = Position;

        return instance;
    }
}
