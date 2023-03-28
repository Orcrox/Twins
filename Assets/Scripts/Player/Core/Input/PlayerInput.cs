using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Vector2 Movement;
    [SerializeField] private bool JumpKey;
    [SerializeField] private bool SprintKey;
    [SerializeField] private bool CrouchKey;

    private void Awake()
    {
        InputActions input = new InputActions();
        input.Player.Enable();

        input.Player.Movement.performed += setMovement;
        input.Player.Movement.canceled += setMovement;

        input.Player.Jump.performed += setJump;
        input.Player.Jump.canceled += setJump;

        input.Player.Sprint.performed += setSprint;
        input.Player.Sprint.canceled += setSprint;

        input.Player.Crouch.performed += setCrouch;
        input.Player.Crouch.canceled += setCrouch;
    }

    public void setMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }
    public Vector2 getMovement()
    {
        return Movement;
    }

    public void setJump(InputAction.CallbackContext context)
    {
        JumpKey = context.ReadValue<float>() == 1 ? true : false;
    }
    public bool getJump()
    {
        return JumpKey;
    }

    public void setSprint(InputAction.CallbackContext context)
    {
        SprintKey = context.ReadValue<float>() == 1 ? true : false;
    }
    public bool getSprint()
    {
        return SprintKey;
    }

    public void setCrouch(InputAction.CallbackContext context)
    {
        CrouchKey = context.ReadValue<float>() == 1 ? true : false;
    }
    public bool getCrouch()
    {
        return CrouchKey;
    }
}
