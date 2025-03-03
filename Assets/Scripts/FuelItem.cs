using UnityEngine;

public class FuelItem : Item
{
    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Player>().AddFuel(Amount);
        Destroy(gameObject);
    }
}