using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // Serialized
    [SerializeField] private new GameObject camera;

    // Private variables
    private float movesSpeed = 10f;
    private Vector2 moveInput, jumpInput;
    private new Rigidbody2D rigidbody2D;

    // Public variables
    public bool grounded = true;

    void Awake()
    {
        // Get player rigidbody component
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        PlayerMove();
        PlayerJump();
    }

    void PlayerMove()
    {
        // Readability
        Vector2 movement = Vector2.zero;

        // Check if grounded
        if(grounded)
        {
            movement = moveInput * movesSpeed * Time.fixedDeltaTime;
        }

        // Add movement to position
        rigidbody2D.MovePosition(rigidbody2D.position + movement);
    }

    void PlayerJump()
    {
        // Readability
        Vector3 up = camera.GetComponent<Camera>().transform.up;
        Vector3 upJumpInput = jumpInput.y * up;
        Debug.Log("upJump: " + upJumpInput);
        Vector3 jump = upJumpInput * movesSpeed * Time.fixedDeltaTime;
        Debug.Log("jump: " + jump);

        // Jump
        if (jump.y > 0f && grounded) {
            rigidbody2D.AddForce(upJumpInput * movesSpeed, ForceMode2D.Impulse);
            Debug.Log("Adding to force");
        }

        // Set grounded
        grounded = Mathf.Approximately(Mathf.Abs(rigidbody2D.velocity.y), 0f);//isGrounded();
        Debug.Log("yVelocity: " + Mathf.Abs(rigidbody2D.velocity.y));
    }

    /*public bool isGrounded()
    {
        
    }*/

    private void OnMove(InputAction.CallbackContext callBackContext)
    {
        moveInput = callBackContext.ReadValue<Vector2>();
        //Debug.Log("Move input " + moveInput);
    }

    private void OnJump(InputAction.CallbackContext callBackContext)
    {
        jumpInput = callBackContext.ReadValue<Vector2>();
        //Debug.Log("Jump input " + jumpInput);
    }
}
