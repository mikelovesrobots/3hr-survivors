using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipbookAnimator : MonoBehaviour
{
    // unity 2d texture frames
    public Sprite[] frames;
    // frame rate
    public float framesPerSecond = 10.0f;

    public SpriteRenderer spriteRenderer;

    void Update()
    {
        // calculate the index
        int index = (int)(Time.time * framesPerSecond) % frames.Length;
        // set the texture
        spriteRenderer.sprite = frames[index];
    }
}
