using Eflatun.SceneReference;
using UnityEditor.SearchService;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SceneReference MainMenuScene;
    [SerializeField] GameObject GameOverUI;
    public static GameManager Instance { get; private set; }
    public Player Player => player;
    Player player;
    int Score;
    float RestartTimer = 3f;

    public bool IsGameOver() => player.GetHealthNormalized() <= 0 || player.GetFuelNormalized() <= 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        player = PlayerTracker.Instance.GetTarget().GetComponent<Player>();
    }

    void Update()
    {
        if (IsGameOver())
        {
            RestartTimer -= Time.deltaTime;

            if (!GameOverUI.activeSelf)
            {
                GameOverUI.SetActive(true);
            }

            if (RestartTimer <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
    }

    public void AddScore(int amount) =>
        Score += amount;


    public int GetScore() => Score;

}
