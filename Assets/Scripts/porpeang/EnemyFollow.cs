using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float stoppingDistance = 0.5f;

    private Vector3 startPosition; // จำจุดเกิด

    private void Start()
    {
        startPosition = transform.position; // บันทึกตำแหน่งตอนเริ่มเกม

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stoppingDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition; // รีเซ็ตกลับตำแหน่งเกิด
    }
}
