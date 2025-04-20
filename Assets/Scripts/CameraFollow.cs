using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 0.125f;

    [SerializeField] private Vector2 minLimit;
    [SerializeField] private Vector2 maxLimit;

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.y);

        Debug.Log("Camera Y: " + transform.position.y + " | Player Y: " + player.transform.position.y);

        //Clamp Cam
        /*float camHalfHeight = Camera.main.orthographicSize;
        float camHalfWidth = camHalfHeight * Camera.main.aspect;

        float clampedX = Mathf.Clamp(smoothedPosition.x, minLimit.x + camHalfWidth, maxLimit.x - camHalfWidth);
        float clampedY = Mathf.Clamp(smoothedPosition.y, minLimit.y + camHalfHeight, maxLimit.y - camHalfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);*/
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
