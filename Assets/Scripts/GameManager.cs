using Eflatun.SceneReference;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject GameWonUI;
    public static GameManager Instance { get; private set; }
    public Player Player => player;
    Player player;
    Boss Boss;
    int Score;
    float RestartTimer = 3f;

    private bool PlayerLost() => player.GetHealthNormalized() <= 0 || player.GetFuelNormalized() <= 0;
    public bool IsGameOver() => PlayerLost() || Boss.IsBossDefeated;
    public bool IsGameWon() => !PlayerLost() && Boss.IsBossDefeated;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        player = PlayerTracker.Instance.GetTarget().GetComponent<Player>();
        Boss = PlayerTracker.Instance.GetBoss().GetComponent<Boss>();
    }

    void Update()
    {
        if (PlayerLost())
        {
            RestartTimer -= Time.deltaTime;
            DeactivatePlayer();
            if (!GameOverUI.activeSelf)
            {
                GameOverUI.SetActive(true);
            }

            if (RestartTimer <= 0)
            {
                GoToMainMenu();
            }
        }
        else if (IsGameWon())
        {
            RestartTimer -= Time.deltaTime;
            DeactivatePlayer();
            if (!GameWonUI.activeSelf)
            {
                GameWonUI.SetActive(true);
            }

            if (RestartTimer <= 0)
            {
                GoToMainMenu();
            }
        }
    }

    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void DeactivatePlayer()
    {
        Player.enabled = false;
        PlayerTracker.Instance.GetTarget().GetComponent<PlayerController>().enabled = false;
        PlayerTracker.Instance.GetTarget().GetComponent<PlayerWeapon>().enabled = false;
    }

    public void ActivatePlayer()
    {
        Player.enabled = true;
        PlayerTracker.Instance.GetTarget().GetComponent<PlayerController>().enabled = true;
        PlayerTracker.Instance.GetTarget().GetComponent<PlayerWeapon>().enabled = true;
    }

    public void AddScore(int amount) =>
        Score += amount;


    public int GetScore() => Score;

    public void StartBossFight() => PlayerTracker.Instance.GetBoss().SetActive(true);
}
