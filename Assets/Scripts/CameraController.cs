using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float Speed = 2f;

    void Start() => transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);

    void LateUpdate()
    {
        transform.position += Vector3.up * Speed * Time.deltaTime;
    }
}