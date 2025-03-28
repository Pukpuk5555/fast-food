using UnityEngine;
using System.Reflection;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForece = 10f;

    private Rigidbody2D rb;
    private bool isGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb);

        if (rb == null) return;

        FieldInfo velocityField = typeof(Rigidbody2D).GetField("velocity", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        if (velocityField != null)
        {
            Vector2 velocity = (Vector2)velocityField.GetValue(rb);
            Debug.Log("Velocity: " + velocity);
        }
        else
        {
            Debug.LogError("‰¡Ëæ∫ field velocity „π Rigidbody2D");
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*MoveByKB();
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }*/
    }

    private void MoveByKB()
    {
        float moveInput = Input.GetAxis("Horizontal");
    }

    private void Jump()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
