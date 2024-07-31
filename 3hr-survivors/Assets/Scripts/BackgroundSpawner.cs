using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject tilemapPrefab; // Assign your tilemap prefab in the Inspector
    public Transform player; // Assign the player transform in the Inspector
    public int tilemapWidth = 10; // Width of your tilemap in units
    public int tilemapHeight = 10; // Height of your tilemap in units
    public int viewDistance = 3; // Number of tilemap segments to load around the player

    private Vector2Int playerPosition;
    private Dictionary<Vector2Int, GameObject> activeTilemaps = new Dictionary<Vector2Int, GameObject>();

    void Start()
    {
        UpdateTilemaps(true);
    }

    void Update()
    {
        Vector2Int newPlayerPosition = new Vector2Int(Mathf.FloorToInt(player.position.x / tilemapWidth), Mathf.FloorToInt(player.position.y / tilemapHeight));
        if (newPlayerPosition != playerPosition)
        {
            playerPosition = newPlayerPosition;
            UpdateTilemaps(false);
        }
    }

    void UpdateTilemaps(bool initialLoad)
    {
        HashSet<Vector2Int> newActiveTilemaps = new HashSet<Vector2Int>();

        for (int x = -viewDistance; x <= viewDistance; x++)
        {
            for (int y = -viewDistance; y <= viewDistance; y++)
            {
                Vector2Int tilemapPosition = new Vector2Int(playerPosition.x + x, playerPosition.y + y);
                newActiveTilemaps.Add(tilemapPosition);

                if (!activeTilemaps.ContainsKey(tilemapPosition))
                {
                    Vector3 worldPosition = new Vector3(tilemapPosition.x * tilemapWidth, tilemapPosition.y * tilemapHeight, 0);
                    GameObject tilemap = Instantiate(tilemapPrefab, worldPosition, Quaternion.identity);
                    tilemap.name = $"BackgroundTilemap ({tilemapPosition.x}, {tilemapPosition.y})";
                    tilemap.transform.SetParent(transform);
                    activeTilemaps.Add(tilemapPosition, tilemap);
                }
            }
        }

        // Remove tilemaps that are no longer in the view distance
        List<Vector2Int> keysToRemove = new List<Vector2Int>();
        foreach (var kvp in activeTilemaps)
        {
            if (!newActiveTilemaps.Contains(kvp.Key))
            {
                Destroy(kvp.Value);
                keysToRemove.Add(kvp.Key);
            }
        }

        foreach (var key in keysToRemove)
        {
            activeTilemaps.Remove(key);
        }
    }
}
