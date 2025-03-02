using UnityEngine;

public class EnemyWeapon : Weapon
{
    float FireTimer;

    void Update()
    {
        FireTimer += Time.deltaTime;

        if (FireTimer >= WeaponStrategy.FireRate)
        {
            WeaponStrategy.Fire(FirePoint, Layer);
            FireTimer = 0f;
        }
    }
}
