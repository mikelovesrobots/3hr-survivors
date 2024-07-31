using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public static Player instance;
    public float moveSpeed = 5f; // Adjust the speed of the player

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from WASD keys
        var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize(); // Normalize the input to ensure consistent movement speed in all directions
        moveVelocity = moveInput * moveSpeed;
    }

    void FixedUpdate()
    {
        // Move the player
        rb.velocity = moveVelocity;
    }
}