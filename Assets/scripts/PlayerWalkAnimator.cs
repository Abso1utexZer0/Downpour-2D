using UnityEngine;

public class PlayerWalkAnimator : MonoBehaviour
{
    public Sprite idleSprite;
    public Sprite walkSprite;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(moveX) > 0.01f)
        {
            sr.sprite = walkSprite;
            sr.flipX = moveX < 0;
        }
        else
        {
            sr.sprite = idleSprite;
        }
    }
}