using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 MoveInput = Vector2.zero;
    public Vector2 LookInput = Vector2.zero;

    public bool JumpIsPressed = false;
    public bool MoveIsPressed = false;

    PlayerInput _input;

    private void OnEnable()
    {
        _input = new PlayerInput();
        _input.onGround.Enable();

        _input.onGround.Move.performed += SetMove; //Read Vector2 value of Move ActionMap
        _input.onGround.Move.canceled += SetMove;

        _input.onGround.Look.performed += SetLook;
        _input.onGround.Look.canceled += SetLook;

        _input.onGround.Jump.performed += SetJump;
        _input.onGround.Jump.canceled += SetJump;
    }

    private void OnDisable()
    {
        _input.onGround.Move.performed -= SetMove; //Read Vector2 value of Move ActionMap
        _input.onGround.Move.canceled -= SetMove;

        _input.onGround.Look.performed -= SetLook;
        _input.onGround.Look.canceled -= SetLook;

        _input.onGround.Jump.performed -= SetJump;
        _input.onGround.Jump.canceled -= SetJump;
    }

    private void SetMove(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector2>();
        MoveIsPressed = !(MoveInput == Vector2.zero); //Return true if MoveInput != Vector2.zero
    }

    private void SetLook(InputAction.CallbackContext ctx)
    {
        LookInput = ctx.ReadValue<Vector2>();
    }

    private void SetJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            JumpIsPressed = true;
        }
        else
        {
            JumpIsPressed = false;
        }
    }
}
