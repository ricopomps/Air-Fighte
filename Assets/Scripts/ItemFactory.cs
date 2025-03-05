using UnityEngine;

public class ItemFactory
{
    public GameObject CreateItem(Item itemPrefab, Vector3 spawnPosition)
    {
        ItemBuilder builder = new ItemBuilder()
            .SetBasePrefab(itemPrefab.gameObject)
            .SetPosition(spawnPosition);

        return builder.Build();
    }
}
