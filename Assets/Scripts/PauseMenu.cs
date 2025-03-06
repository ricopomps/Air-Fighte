using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    bool IsPaused = false;
    [SerializeField] Button ResumeButton;
    [SerializeField] Button MainMenuButton;
    [SerializeField] Button QuitButton;

    void Awake()
    {
        ResumeButton.onClick.AddListener(() => ResumeGame());
        MainMenuButton.onClick.AddListener(() => GameManager.Instance.GoToMainMenu());
        QuitButton.onClick.AddListener(() => Helpers.QuitGame());
        Time.timeScale = 1f;
    }

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            if (IsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        GameManager.Instance.DeactivatePlayer();
        pauseMenu.SetActive(true);
        IsPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        GameManager.Instance.ActivatePlayer();
        pauseMenu.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1f;
    }
}
