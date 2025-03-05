using UnityEngine;
using UnityEngine.UI;

public class Player : Plane
{
    [SerializeField] float MaxFuel;
    [SerializeField] float FuelConsumptionRate;
    [SerializeField] GameObject Shield;
    [SerializeField] Image ShieldImage;
    InputReader Input;

    float Fuel;
    private bool IsShieldActive = false;
    float ShieldTimer;
    float ShieldCooldown = 10f;
    float ShieldDuration = 3f;
    float ShieldActiveTimer;

    public float GetFuelNormalized() => Fuel / MaxFuel;

    void Start()
    {
        Fuel = MaxFuel;
        Input = GetComponent<InputReader>();
        ShieldTimer = ShieldCooldown;
    }

    void Update()
    {
        ShieldTimer += Time.deltaTime;
        Fuel -= FuelConsumptionRate * Time.deltaTime;

        if (Input.FirstAbility && ShieldTimer >= ShieldCooldown)
        {
            ActivateShield();
        }

        if (IsShieldActive)
        {
            ShieldActiveTimer += Time.deltaTime;
            if (ShieldActiveTimer >= ShieldDuration)
            {
                DeactivateShield();
            }
        }

        ShieldImage.fillAmount = GetShieldFillAmount();
    }

    public void AddFuel(float amount)
    {
        Fuel += amount;
        if (Fuel > MaxFuel)
        {
            Fuel = MaxFuel;
        }
    }

    public void ActivateShield()
    {
        Shield.SetActive(true);
        IsShieldActive = true;
        ShieldActiveTimer = 0f;
        ShieldTimer = 0f;
        Fuel -= GetShieldFuelConsumption();
        ShieldImage.fillAmount = 1;
    }

    public float GetShieldFuelConsumption()
    {
        return MaxFuel * 0.2f;
    }

    public void DeactivateShield()
    {
        Shield.SetActive(false);
        IsShieldActive = false;
    }

    public float GetShieldFillAmount()
    {
        if (IsShieldActive || ShieldTimer < ShieldCooldown)
        {
            return 1 - (ShieldTimer / ShieldCooldown);
        }
        return 0;
    }

    public override void TakeDamage(int amount)
    {
        if (!IsShieldActive)
        {
            base.TakeDamage(amount);
        }
    }

    protected override void Die()
    {
        //throw new System.NotImplementedException();
    }
}
