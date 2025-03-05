using UnityEngine;

public class BulletItem : Item
{
    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Player>().AddShots((int)Amount);
        Destroy(gameObject);
    }
}