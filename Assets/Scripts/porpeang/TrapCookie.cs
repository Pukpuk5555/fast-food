using UnityEngine;

public class TrapCookie : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveDistance = 2f;
    [SerializeField] private float moveSpeed = 2f;

    private Vector3 startPos;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos + Vector3.up * moveDistance, step);
            if (Vector3.Distance(transform.position, startPos + Vector3.up * moveDistance) < 0.01f)
                movingUp = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            if (Vector3.Distance(transform.position, startPos) < 0.01f)
                movingUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().SendMessage("Respawn");
        }
    }
}
