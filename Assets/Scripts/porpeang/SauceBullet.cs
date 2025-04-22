using UnityEngine;

public class SauceBullet : MonoBehaviour
{
    //[SerializeField] private float speed = 5f;

    void Update()
    {
        //ransform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // เรียกการ respawn ของ Player
            collision.GetComponent<Player>().SendMessage("Respawn");

            // ทำลาย fireball หลังจากโดน
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject); // กระสุนหายเมื่อชนพื้น
        }
        else if (collision.CompareTag("Dead"))
        {
            Destroy(gameObject); // กระสุนหายเมื่อชนพื้น
        }
    }
}
