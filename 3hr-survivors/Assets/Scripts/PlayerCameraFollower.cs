using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFollower : MonoBehaviour
{
    void Update()
    {
        var playerPosition = Player.instance.transform.position;
        var cameraPosition = Camera.main.transform.position;
        cameraPosition.x = playerPosition.x;
        cameraPosition.y = playerPosition.y;

        Camera.main.transform.position = cameraPosition;
    }
}
