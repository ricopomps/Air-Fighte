using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] GameObject Boss;
    public static PlayerTracker Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetTarget() => Target;
    public GameObject GetBoss() => Boss;
}
