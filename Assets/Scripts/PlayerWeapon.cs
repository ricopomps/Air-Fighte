using UnityEngine;

public class PlayerWeapon : Weapon
{
    InputReader Input;
    float FireTimer;

    void Awake() => Input = GetComponent<InputReader>();

    void Update()
    {
        FireTimer += Time.deltaTime;

        if (Input.Fire && FireTimer >= WeaponStrategy.FireRate)
        {
            WeaponStrategy.Fire(FirePoint, Layer);
            FireTimer = 0f;
        }
    }
}
