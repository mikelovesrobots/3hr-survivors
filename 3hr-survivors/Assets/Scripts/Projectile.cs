using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float lifespan = 1f;

    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * moveSpeed;

        // Destroy the projectile after a certain amount of seconds
        Destroy(gameObject, lifespan);
    }
}
