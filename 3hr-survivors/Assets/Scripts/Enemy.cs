using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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