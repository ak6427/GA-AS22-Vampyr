using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // Private variables
    private float moveSpeed = 10f;
    private Vector2 moveInput, jumpInput, movement;
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
        // Check if grounded
        if(grounded)
        {
            movement = moveInput * moveSpeed * Time.fixedDeltaTime;
        }

        // Add movement to position
        rigidbody2D.MovePosition(rigidbody2D.position + movement);
    }

    void PlayerJump()
    {
        // Readability
        Vector2 upJumpInput = jumpInput.y * transform.up * moveSpeed * Time.fixedDeltaTime;

        // Jump
        if (upJumpInput.y > 0f && grounded) 
        {
            rigidbody2D.AddForce(upJumpInput, ForceMode2D.Impulse);
            Debug.Log("upJump: " + upJumpInput);
            Debug.Log("Adding to force");
        }

        // Set grounded
        grounded = Mathf.Approximately(Mathf.Abs(rigidbody2D.velocity.y), 0f);
        Debug.Log("yVelocity: " + Mathf.Abs(rigidbody2D.velocity.y));
    }

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
