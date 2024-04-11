using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(Camera))]
public class AspectRatioEnforcer : MonoBehaviour
{
    public float width = 24;
    public float height = 10;
    private Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
         Debug.Log("Start: camera = " + camera); 
         Debug.Log("Start: camera = " + camera);
    }

    void Update()
    {
        Debug.Log("Update: camera = " + camera);
        float targetAspect = width / height;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;
        Rect rect = camera.rect;

        if (scaleHeight < 1.0f)
        {
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
        }

        camera.rect = rect;
    }
}