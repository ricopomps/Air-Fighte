using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputReader : MonoBehaviour
{
    PlayerInput PlayerInput;
    InputAction MoveAction;
    InputAction FireAction;
    InputAction FirstAbilityAction;

    public Vector2 Move => MoveAction.ReadValue<Vector2>();

    public bool Fire => FireAction.ReadValue<float>() > 0f;
    public bool FirstAbility => FirstAbilityAction.ReadValue<float>() > 0f;

    void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
        MoveAction = PlayerInput.actions["Move"];
        FireAction = PlayerInput.actions["Fire"];
        FirstAbilityAction = PlayerInput.actions["FirstAbility"];
    }
}