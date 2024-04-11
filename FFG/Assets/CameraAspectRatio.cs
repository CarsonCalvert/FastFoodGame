using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAspectRatio : MonoBehaviour
{
    private Camera cam;
    private float initialAspect;
    private float initialOrthographicSize;

    void Start()
    {
        // Set the game window's resolution to 600x150 pixels
        Screen.SetResolution(600, 150, false);

        cam = GetComponent<Camera>();
        initialAspect = cam.aspect;
        initialOrthographicSize = cam.orthographicSize;
    }

    void Update()
    {
        // Adjust the camera's orthographic size based on the current aspect ratio to maintain a consistent view
        cam.orthographicSize = initialOrthographicSize * (initialAspect / cam.aspect);
    }
}