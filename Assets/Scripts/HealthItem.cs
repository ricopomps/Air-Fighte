using UnityEngine;

public class HealthItem : Item
{
    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Player>().AddHealth((int)Amount);
        Destroy(gameObject);
    }
}