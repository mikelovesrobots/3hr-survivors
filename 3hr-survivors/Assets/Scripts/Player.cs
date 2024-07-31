using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed of the player
    public SpriteFlipbookAnimator spriteFlipbookAnimator;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from WASD keys
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize(); // Normalize the input to ensure consistent movement speed in all directions
        moveVelocity = moveInput * moveSpeed;
    }

    void FixedUpdate()
    {
        // Move the player
        rb.velocity = moveVelocity;

        // Rotate the sprite based on the direction of movement
        if (moveVelocity.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveVelocity.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // If moveVelocity is not zero, play the walk animation
        if (moveVelocity != Vector2.zero)
        {
            spriteFlipbookAnimator.isPlaying = true;
        }
        else
        {
            spriteFlipbookAnimator.isPlaying = false;
        }
    }
}