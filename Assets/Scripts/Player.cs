using UnityEngine;

public class Player : Plane
{
    [SerializeField] float MaxFuel;
    [SerializeField] float FuelConsumptionRate;

    float Fuel;

    public float GetFuelNormalized() => Fuel / MaxFuel;

    void Start() => Fuel = MaxFuel;

    void Update()
    {
        Fuel -= FuelConsumptionRate * Time.deltaTime;
    }

    public void AddFuel(int amount)
    {
        Fuel += amount;
        if (Fuel > MaxFuel)
        {
            Fuel = MaxFuel;
        }
    }

    protected override void Die()
    {
        //throw new System.NotImplementedException();
    }
}
