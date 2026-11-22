using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float horizontalInput;
    public float moveSpeed = 5f;
    private bool isJumpPressed;
    public float jumpForce = 5f;
    private bool isWalking;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }

        Debug.Log("Horizontal Input: " + horizontalInput);
        
        if (horizontalInput > 0)
        {
            isWalking = true;
            moveSpeed = 5f;
        }
        else
        {
            isWalking = false;
            moveSpeed = 0;
        }
    }

    void FixedUpdate()
    {
        float x = moveSpeed * horizontalInput;
        float y = _rigidbody2D.linearVelocity.y;
        _rigidbody2D.linearVelocity = new Vector2(x, y);

        if (isJumpPressed)
        {
            _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.x, jumpForce);
            isJumpPressed = false;
        }
    }
}
