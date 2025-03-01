using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputReader : MonoBehaviour
{
    PlayerInput PlayerInput;
    InputAction MoveAction;

    public Vector2 Move => MoveAction.ReadValue<Vector2>();

    void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
        MoveAction = PlayerInput.actions["Move"];
    }
}