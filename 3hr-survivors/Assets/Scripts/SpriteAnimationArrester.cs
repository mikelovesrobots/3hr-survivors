using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteFlipbookAnimator))]
public class SpriteAnimationArrester : MonoBehaviour
{
  private Rigidbody2D rb;
  private SpriteFlipbookAnimator spriteFlipbookAnimator;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    spriteFlipbookAnimator = GetComponent<SpriteFlipbookAnimator>();
  }

  void Update()
  {
    if (rb.velocity != Vector2.zero)
    {
      spriteFlipbookAnimator.isPlaying = true;
    }
    else
    {
      spriteFlipbookAnimator.isPlaying = false;
    }
  }
}