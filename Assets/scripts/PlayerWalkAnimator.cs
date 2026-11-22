using UnityEngine;

public class PlayerWalkAnimator : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Vector3 lastPosition;
    public bool isWalking;
    private float horizontalInput;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
        lastPosition = transform.position;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void LateUpdate()
    {
        float moveSpeed = (transform.position - lastPosition).x / Time.deltaTime;
        lastPosition = transform.position;

        if (Mathf.Approximately(moveSpeed, 0f) && rb != null)
        {
            moveSpeed = rb.linearVelocity.x;
        }

        animator.SetFloat("Speed", moveSpeed);
    }
}