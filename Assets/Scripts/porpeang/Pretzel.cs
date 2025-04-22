using UnityEngine;

public class Pretzel : MonoBehaviour
{
    public Transform pivotPoint; // จุดหมุน (ปลายแท่งด้านบน)
    public float rotationSpeed = 50f; // ความเร็วในการหมุน
    public float angleRange = 45f; // มุมสูงสุดที่ลูกตุ้มจะเหวี่ยงถึง

    private float currentAngle = 0f;
    private float direction = 1f;

    void Update()
    {
        float angleChange = rotationSpeed * Time.deltaTime * direction;
        currentAngle += angleChange;

        // เปลี่ยนทิศทางเมื่อถึงขีดจำกัด
        if (Mathf.Abs(currentAngle) > angleRange)
        {
            direction *= -1f;
        }

        transform.RotateAround(pivotPoint.position, Vector3.forward, angleChange);
    }
}
