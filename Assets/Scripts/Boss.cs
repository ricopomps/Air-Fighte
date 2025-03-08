using System;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100f;
    [SerializeField] GameObject ExplosionPrefab;
    [SerializeField] GameObject HealthBar;
    float Health;
    public bool IsBossDefeated = false;

    Collider BossCollider;

    public List<BossStage> Stages;
    int CurrentStage = 0;

    void Awake()
    {
        Health = MaxHealth;
        BossCollider = GetComponent<Collider>();
    }

    void Start()
    {
        SetBossColiderEnabled(true);

        InitializeStage();
    }

    void SetBossColiderEnabled(bool enabled)
    {
        BossCollider.enabled = enabled;
        HealthBar.SetActive(enabled);
    }

    public float GetHealthNormalized() => Health / MaxHealth;

    void CheckStageComplete()
    {
        if (CurrentStage >= 0 && CurrentStage < Stages.Count && Stages[CurrentStage].IsStageComplete())
        {
            AdvanceToNextStage();
        }
    }

    void AdvanceToNextStage()
    {
        CurrentStage++;
        SetBossColiderEnabled(true);

        if (CurrentStage < Stages.Count)
        {
            InitializeStage();
        }
    }

    void InitializeStage()
    {
        Stages[CurrentStage].InitializeStage();

        foreach (var system in Stages[CurrentStage].EnemySystems)
        {
            system.OnSystemDestroyed.AddListener(CheckStageComplete);
        }

        SetBossColiderEnabled(!Stages[CurrentStage].IsBossInvulnerable);
    }

    void OnCollisionEnter(Collision other)
    {
        Health -= 10;
        OnHealthChanged?.Invoke();
        if (Health <= 0)
        {
            BossDefeated();
        }
    }

    void BossDefeated()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        IsBossDefeated = true;
        Destroy(gameObject);
    }

    public event Action OnHealthChanged;
}
