using UnityEngine;

public class LandController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerMovement _input;

    public Vector3 playerMoveInput;
    Camera cam;

    [Header("Movement")]
    [SerializeField] float _movementMultiplier = 30.0f;



    void Start()
    {
        playerMoveInput = Vector3.zero;
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        groundControl();
        jumpControl();
    }

    void groundControl()
    {
        playerMoveInput = GetMoveInput();
        PlayerMove();

        Vector3 forceDirection = cam.transform.forward;
        forceDirection.y = 0; // Ensure we only move in the horizontal plane
        forceDirection.Normalize();

        if (playerMoveInput != Vector3.zero)
            rb.AddForce(forceDirection * 10 * Time.deltaTime, ForceMode.Impulse);
    }

    void jumpControl()
    {
        if(_input.JumpIsPressed)
        {
            _input.JumpIsPressed = false;
            //Jump Player
            float magnitude = 6f;
            rb.AddForce(Vector3.up * magnitude, ForceMode.Impulse);

            _input.MoveIsPressed = false;
        }
    }
    private Vector3 GetMoveInput()
    {
        return new Vector3(_input.MoveInput.x, 0, _input.MoveInput.y);
    }

    private void PlayerMove()
    {
        playerMoveInput = new Vector3(playerMoveInput.x * _movementMultiplier * rb.mass,
                                      playerMoveInput.y,
                                      playerMoveInput.z * _movementMultiplier * rb.mass);
    }
}
