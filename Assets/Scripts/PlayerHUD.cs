using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Image HealthBar;
    [SerializeField] Image FuelBar;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI GameWonScoreText;

    void Update()
    {
        HealthBar.fillAmount = GameManager.Instance.Player.GetHealthNormalized();
        FuelBar.fillAmount = GameManager.Instance.Player.GetFuelNormalized();
        ScoreText.text = $"Score: {GameManager.Instance.GetScore()}";
        GameWonScoreText.text = $"Score: {GameManager.Instance.GetScore()}";
    }
}
