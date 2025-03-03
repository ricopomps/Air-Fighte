using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] Boss Boss;
    [SerializeField] Image HealthBar;

    void Awake()
    {
        Boss.OnHealthChanged += OnHealthChanged;
    }

    void OnHealthChanged()
    {
        HealthBar.fillAmount = Boss.GetHealthNormalized();
    }
}
