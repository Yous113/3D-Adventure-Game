using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Camera mainCamera;
    public SpriteRenderer backgroundRenderer;
    private Vector2 backgroundSize;

    void Start()
    {
        UpdateBackgroundSize();
    }

    void Update()
    {
        if (mainCamera.orthographicSize * 2 != backgroundSize.y)
        {
            UpdateBackgroundSize();
        }
        transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 10);

    }

    private void UpdateBackgroundSize()
    {
        float cameraHeight = mainCamera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        float backgroundWidth = backgroundRenderer.sprite.bounds.size.x;
        float backgroundHeight = backgroundRenderer.sprite.bounds.size.y;
        float scaleX = (cameraWidth / backgroundWidth) + 0.1f;
        float scaleY = (cameraHeight / backgroundHeight) + 0.1f;
        transform.localScale = new Vector3(scaleX, scaleY, 1f);
        backgroundSize = new Vector2(cameraWidth, cameraHeight);
    }
}
