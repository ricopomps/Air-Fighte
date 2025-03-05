using UnityEngine;
using UnityEngine.UI;

public class Player : Plane
{
    [SerializeField] float MaxFuel;
    [SerializeField] float FuelConsumptionRate;
    [SerializeField] GameObject Shield;
    [SerializeField] Image ShieldImage;
    [SerializeField] Image SpeedBoostImage;
    InputReader Input;
    PlayerController Controller;

    float Fuel;
    private bool IsShieldActive = false;
    float ShieldTimer;
    float ShieldCooldown = 10f;
    float ShieldDuration = 3f;
    float ShieldActiveTimer;

    private bool IsSpeedBoostActive = false;
    float SpeedBoostTimer;
    float SpeedBoostCooldown = 10f;
    float SpeedBoostDuration = 3f;
    float SpeedBoostActiveTimer;


    public float GetFuelNormalized() => Fuel / MaxFuel;

    void Start()
    {
        Fuel = MaxFuel;
        Input = GetComponent<InputReader>();
        Controller = GetComponent<PlayerController>();
        ShieldTimer = ShieldCooldown;
        SpeedBoostTimer = SpeedBoostCooldown;
    }

    void Update()
    {
        ShieldTimer += Time.deltaTime;
        SpeedBoostTimer += Time.deltaTime;
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

        if (Input.SecondAbility && SpeedBoostTimer >= SpeedBoostCooldown)
        {
            ActivateSpeedBoost();
        }

        if (IsSpeedBoostActive)
        {
            SpeedBoostActiveTimer += Time.deltaTime;
            if (SpeedBoostActiveTimer >= SpeedBoostDuration)
            {
                DeactivateSpeedBoost();
            }
        }

        ShieldImage.fillAmount = GetShieldFillAmount();
        SpeedBoostImage.fillAmount = GetSpeedBoostFillAmount();
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

    public void ActivateSpeedBoost()
    {
        IsSpeedBoostActive = true;
        SpeedBoostActiveTimer = 0f;
        SpeedBoostTimer = 0f;
        Fuel -= GetSpeedBoostFuelConsumption();
        SpeedBoostImage.fillAmount = 1;
        Controller.ActivateSpeedBoost();
    }

    public float GetSpeedBoostFuelConsumption()
    {
        return MaxFuel * 0.2f;
    }

    public void DeactivateSpeedBoost()
    {
        IsSpeedBoostActive = false;
        Controller.DeactivateSpeedBoost();
    }

    public float GetSpeedBoostFillAmount()
    {
        if (IsSpeedBoostActive || SpeedBoostTimer < SpeedBoostCooldown)
        {
            return 1 - (SpeedBoostTimer / SpeedBoostCooldown);
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
