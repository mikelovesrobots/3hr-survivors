using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteHitFlasher))]
public class Player : MonoBehaviour
{
    public static Player instance;
    public float moveSpeed = 5f; // Adjust the speed of the player
    public int hitPoints = 10;

    // projectiles
    public GameObject projectilePrefab; // Assign the projectile prefab in the inspector
    public float spawnInterval = 2f; // Time interval between projectile spawns

    // movement
    private Vector2 moveVelocity;

    // dependencies
    private Rigidbody2D rb;
    private SpriteHitFlasher spriteHitFlasher;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteHitFlasher = GetComponent<SpriteHitFlasher>();
        StartCoroutine(SpawnProjectileRoutine());
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

    IEnumerator SpawnProjectileRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            Vector3 direction = (nearestEnemy.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            Instantiate(projectilePrefab, transform.position, rotation);
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy;
        if (collision.gameObject.TryGetComponent<Enemy>(out enemy))
        {
            Hit();
        }
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
}