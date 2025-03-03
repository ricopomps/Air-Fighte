using System;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100f;
    [SerializeField] GameObject ExplosionPrefab;
    float Health;

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
        BossCollider.enabled = true;

        InitializeStage();
    }

    public float GetHealthNormalized() => Health / MaxHealth;

    void CheckStageComplete()
    {
        if (Stages[CurrentStage].IsStageComplete())
        {
            AdvanceToNextStage();
        }
    }

    void AdvanceToNextStage()
    {
        CurrentStage++;
        BossCollider.enabled = true;

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

        BossCollider.enabled = !Stages[CurrentStage].IsBossInvulnerable;
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
        Destroy(gameObject);
    }

    public event Action OnHealthChanged;
}
