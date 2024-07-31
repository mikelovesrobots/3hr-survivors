using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpriteDirectionController : MonoBehaviour
{
  private Rigidbody2D rb;
  private bool isFacingRight = true;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {

    if (rb.velocity.x > 0 && !isFacingRight)
    {
      isFacingRight = true;
      transform.localScale = new Vector2(-1, 1);
    }
    else if (rb.velocity.x < 0 && isFacingRight)
    {
      isFacingRight = false;
      transform.localScale = new Vector2(1, 1);
    }
  }
}