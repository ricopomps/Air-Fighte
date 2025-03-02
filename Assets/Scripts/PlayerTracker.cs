using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] GameObject Target;
    public static PlayerTracker Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetTarget() => Target;
}
