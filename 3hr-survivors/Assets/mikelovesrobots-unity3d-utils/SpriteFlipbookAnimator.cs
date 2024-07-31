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
    public bool isPlaying = true;

    void Update()
    {
        // calculate the index
        int index = (int)(Time.time * framesPerSecond) % frames.Length;
        // set the texture
        spriteRenderer.sprite = isPlaying ? frames[index] : frames[0];
    }
}
