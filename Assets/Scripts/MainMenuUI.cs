using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] SceneReference StartingLevel;
    [SerializeField] Button PlayButton;
    [SerializeField] Button QuitButton;
    [SerializeField] Button ControlsButton;
    [SerializeField] Button ReturnMainMenuButton;
    [SerializeField] Canvas ControlsCanvas;
    bool ShowControls = false;

    void SetShowControls(bool showControls)
    {
        ShowControls = showControls;
        if (ShowControls)
        {
            PlayButton.gameObject.SetActive(false);
            QuitButton.gameObject.SetActive(false);
            ControlsButton.gameObject.SetActive(false);
            ReturnMainMenuButton.gameObject.SetActive(true);
            ControlsCanvas.gameObject.SetActive(true);
        }
        else
        {
            PlayButton.gameObject.SetActive(true);
            QuitButton.gameObject.SetActive(true);
            ControlsButton.gameObject.SetActive(true);
            ReturnMainMenuButton.gameObject.SetActive(false);
            ControlsCanvas.gameObject.SetActive(false);
        }
    }

    void Awake()
    {
        SetShowControls(false);
        PlayButton.onClick.AddListener(() => Loader.Load(StartingLevel));
        QuitButton.onClick.AddListener(() => Helpers.QuitGame());
        ControlsButton.onClick.AddListener(() => SetShowControls(true));
        ReturnMainMenuButton.onClick.AddListener(() => SetShowControls(false));
        Time.timeScale = 1f;
    }
}
