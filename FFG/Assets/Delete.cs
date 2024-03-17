using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    public Vector3 spawnPosition;

    void Update()
    {
        // If the obstacle moves off the screen, move it back to the spawn position
        if (transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * Screen.width / Screen.height)
        {
            transform.position = spawnPosition;
        }
    }
}