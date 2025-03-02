using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] SceneReference StartingLevel;
    [SerializeField] Button PlayButton;
    [SerializeField] Button QuitButton;

    void Awake()
    {
        PlayButton.onClick.AddListener(() => Loader.Load(StartingLevel));
        QuitButton.onClick.AddListener(() => Helpers.QuitGame());
        Time.timeScale = 1f;
    }
}
