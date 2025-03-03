using System.Collections.Generic;
using UnityEngine;

public class BossStage : MonoBehaviour
{
    public List<Enemy> EnemySystems;
    public bool IsBossInvulnerable = true;

    void Awake()
    {
        foreach (var system in EnemySystems)
        {
            system.gameObject.SetActive(false);
        }
    }

    public void InitializeStage()
    {
        foreach (var system in EnemySystems)
        {
            system.gameObject.SetActive(true);
        }
    }

    public bool IsStageComplete()
    {
        foreach (var system in EnemySystems)
        {
            if (system != null && system.GetHealthNormalized() > 0)
            {
                return false;
            }
        }

        return true;
    }
}
