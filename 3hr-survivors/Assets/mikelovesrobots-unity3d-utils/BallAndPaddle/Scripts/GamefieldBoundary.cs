using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamefieldBoundary : MonoBehaviour
{
    public Vector2 maxBounds;
    public Vector2 minBounds;
    public EdgeCollider2D TopWall;
    public EdgeCollider2D LeftWall;
    public EdgeCollider2D BottomWall;
    public EdgeCollider2D RightWall;

    private void Start()
    {
        // Set wall points to bounds
        TopWall.points = new Vector2[] { new Vector2(minBounds.x, maxBounds.y), new Vector2(maxBounds.x, maxBounds.y) };
        LeftWall.points = new Vector2[] { new Vector2(minBounds.x, minBounds.y), new Vector2(minBounds.x, maxBounds.y) };
        BottomWall.points = new Vector2[] { new Vector2(minBounds.x, minBounds.y), new Vector2(maxBounds.x, minBounds.y) };
        RightWall.points = new Vector2[] { new Vector2(maxBounds.x, minBounds.y), new Vector2(maxBounds.x, maxBounds.y) };
    }

    // run in edit mode
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(minBounds.x, minBounds.y), new Vector2(maxBounds.x, minBounds.y));
        Gizmos.DrawLine(new Vector2(maxBounds.x, minBounds.y), new Vector2(maxBounds.x, maxBounds.y));
        Gizmos.DrawLine(new Vector2(maxBounds.x, maxBounds.y), new Vector2(minBounds.x, maxBounds.y));
        Gizmos.DrawLine(new Vector2(minBounds.x, maxBounds.y), new Vector2(minBounds.x, minBounds.y));
    }
}
