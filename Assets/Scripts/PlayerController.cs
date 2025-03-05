using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed = 5f;
    [SerializeField] float Smoothness = 0.1f;
    [SerializeField] float LeanAngle = 15f;
    [SerializeField] float LeanSpeed = 5f;

    [Header("Camera Bounds")]
    [SerializeField] Transform CameraFollow;

    [SerializeField] float MinX = -8f;
    [SerializeField] float MaxX = 8f;
    [SerializeField] float MinY = -4f;
    [SerializeField] float MaxY = 4f;

    InputReader Input;

    Vector3 CurrentVelocity;
    Vector3 TargetPosition;

    void Start()
    {
        Input = GetComponent<InputReader>();
    }

    public void ActivateSpeedBoost()
    {
        Speed *= 2;
    }

    public void DeactivateSpeedBoost()
    {
        Speed /= 2;
    }

    void Update()
    {
        TargetPosition += new Vector3(Input.Move.x, Input.Move.y, 0f) * (Speed * Time.deltaTime);

        var minPlayerX = CameraFollow.position.x + MinX;
        var maxPlayerX = CameraFollow.position.x + MaxX;
        var minPlayerY = CameraFollow.position.y + MinY;
        var maxPlayerY = CameraFollow.position.y + MaxY;

        TargetPosition.x = Mathf.Clamp(TargetPosition.x, minPlayerX, maxPlayerX);
        TargetPosition.y = Mathf.Clamp(TargetPosition.y, minPlayerY, maxPlayerY);

        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref CurrentVelocity, Smoothness);

        var targetRotationAngle = -Input.Move.x * LeanAngle;
        var currentYRotation = transform.localEulerAngles.y;
        var newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, LeanSpeed * Time.deltaTime);

        transform.localEulerAngles = new Vector3(0f, newYRotation, 0f);
    }
}