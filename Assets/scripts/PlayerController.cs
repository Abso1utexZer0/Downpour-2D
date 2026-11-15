using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float horizontalInput;
    public float moveSpeed = 5f;
    private bool isJumpPressed;
    public float jumpForce = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }

        Debug.Log("Horizontal Input: " + horizontalInput);
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
