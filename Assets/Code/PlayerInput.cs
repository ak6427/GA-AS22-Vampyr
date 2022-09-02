using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // Private variables
    private Vector2 moveInput, jumpInput, dropInput, movement, movementXvector;
    private new Rigidbody2D rigidbody2D;
    private float movementX, movementY;

    // Public variables
    public float moveSpeed = 10f, jumpForce = 5f;
    public bool grounded = false;

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
        // Movement values
        movementX = moveInput.x * moveSpeed * Time.fixedDeltaTime;
        movementY = jumpInput.y * jumpForce;
        movement = new Vector2(movementX, movementY);
        movementXvector = new Vector2(movementX, 0f);
    }

    void FixedUpdate()
    {
        PlayerMove(movement, movementXvector);
    }

    void PlayerMove(Vector2 movement, Vector2 movementXvector)
    {
        // Check if grounded
        if(grounded)
        {
                rigidbody2D.AddForce(movement, ForceMode2D.Impulse);
        }
        rigidbody2D.AddForce(movementXvector, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 2);
        return hit.collider != null && Mathf.Approximately(rigidbody2D.velocity.y, 0f);
    }

    // Return input action values
    public void Move(InputAction.CallbackContext callBackContext)
    {
        moveInput = callBackContext.ReadValue<Vector2>();
        //Debug.Log("Move input " + moveInput);
    }
    public void Jump(InputAction.CallbackContext callBackContext)
    {
        jumpInput = callBackContext.ReadValue<Vector2>();
        //Debug.Log("Move input " + moveInput);
    }
    public void Drop(InputAction.CallbackContext callBackContext)
    {
        dropInput = callBackContext.ReadValue<Vector2>();
        //Debug.Log("Move input " + moveInput);
    }

    // Return collision target values
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Enter: " + collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if grounded and set bool
        grounded = IsGrounded();

        //Debug.Log("Stay: " + collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Set grounded to false up exiting collision
        grounded = false;

        //Debug.Log("Exit: " + collision);
    }
}
