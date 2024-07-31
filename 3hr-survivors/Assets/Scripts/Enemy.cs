using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteHitFlasher))]
public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int hitPoints = 3; // Number of hitpoints the enemy has
    private Rigidbody2D rb;
    private Vector2 direction;
    private SpriteHitFlasher spriteHitFlasher;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteHitFlasher = GetComponent<SpriteHitFlasher>();
    }

    public void Hit()
    {
        hitPoints--;
        spriteHitFlasher.Flash();
        if (hitPoints <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    void Update()
    {
        if (Player.instance != null)
        {
            Vector2 playerPosition = Player.instance.transform.position;
            direction = playerPosition - (Vector2)transform.position;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = direction.normalized * moveSpeed;
    }

}