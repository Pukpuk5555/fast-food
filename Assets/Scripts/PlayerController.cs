using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 5f;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }

    [SerializeField] 
    private float jumpForece = 7f;
    public float JumpForce { get { return jumpForece; } set { jumpForece = value; } }

    [SerializeField] private float bootSpeed = 10f;
    [SerializeField] private float bootDuration = 5f;
    private bool isBoosting = false;

    private Rigidbody2D rb;
    private bool isGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb);
    }

    // Update is called once per frame
    void Update()
    {
        MoveByKB();

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
    }

    private void MoveByKB()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocityY);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForece);
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

    public void StartSpeedBoost()
    {
        if (!isBoosting)
            StartCoroutine(SpeedBoost());
    }

    private IEnumerator SpeedBoost()
    {
        isBoosting = true;

        float originalSpeed = moveSpeed;
        moveSpeed = bootSpeed;

        yield return new WaitForSeconds(bootDuration);

        moveSpeed = originalSpeed;
        isBoosting = false;
    }
}
