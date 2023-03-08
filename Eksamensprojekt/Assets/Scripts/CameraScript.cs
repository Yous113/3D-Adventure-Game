using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform player1;
    public Transform player2;
    public Vector3 offset;
    public float smoothTime = 0.3f;
    public float maxXDistance = 3f;

    private Vector3 velocity = Vector3.zero;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        // Calculate the center point between both players
        Vector3 centerPoint = (player1.position + player2.position) / 2f;

        // Calculate the desired position of the camera based on the center point and offset
        Vector3 desiredPosition = centerPoint + offset;

        // Check if both players are within the camera's frustum
        Vector3 viewportPoint1 = cam.WorldToViewportPoint(player1.position);
        Vector3 viewportPoint2 = cam.WorldToViewportPoint(player2.position);
        bool bothInViewport = viewportPoint1.x > 0 && viewportPoint1.x < 1 && viewportPoint1.y > 0 && viewportPoint1.y < 1
            && viewportPoint2.x > 0 && viewportPoint2.x < 1 && viewportPoint2.y > 0 && viewportPoint2.y < 1;

        // If both players are not within the camera's frustum, adjust the camera's position
        if (!bothInViewport)
        {
            // Calculate the distance between both players
            float distance = Vector3.Distance(player1.position, player2.position);

            // Calculate the size of the frustum that contains both players
            float frustumHeight = distance / cam.aspect;
            float frustumWidth = frustumHeight / cam.aspect;
            float frustumSize = Mathf.Max(frustumWidth, frustumHeight);

            // Calculate the desired position of the camera to contain both players
            Vector3 direction = (player2.position - player1.position).normalized;
            Vector3 newCenterPoint = centerPoint + (direction * frustumSize * 0.5f);
            desiredPosition = newCenterPoint + offset;
        }
        else
        {
            // If both players are within the camera's frustum, keep their x position fixed
            float xDistance = Mathf.Abs(player1.position.x - player2.position.x);
            if (xDistance > maxXDistance)
            {
                float center = (player1.position.x + player2.position.x) / 2f;
                float targetX = Mathf.Clamp(center, player1.position.x + maxXDistance / 2f, player2.position.x - maxXDistance / 2f);
                desiredPosition.x = targetX;
            }
        }

        // Move the camera towards the desired position using a smooth damp function
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.position = smoothPosition;
    }
}
