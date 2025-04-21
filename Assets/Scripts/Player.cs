using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStats stats;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private PlayerController playerController;
    private RuntimeAnimatorController currentAnim;
    private Rigidbody2D rb;

    [Header("Player Sprite")]
    [SerializeField]
    private Sprite healthySprite, normalSprite, fatSprite, superFatSprite;

    [Header("Player Animator")]
    [SerializeField]
    private RuntimeAnimatorController healthyAnim, normalAnim, fatAnim, superFatAnim;

    [SerializeField] GameObject respawnPoint;

    [SerializeField] private GameObject finishGameUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        stats = GetComponent<PlayerStats>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        playerController = GetComponent<PlayerController>();

        finishGameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVisuals(stats.FatValue);
    }

    private void UpdateVisuals(float fat)
    {
        RuntimeAnimatorController newAnim = null;

        if (fat <= 10)
        {
            spriteRenderer.sprite = healthySprite;
            newAnim = healthyAnim;
            playerController.MoveSpeed = 7f;
            playerController.JumpForce = 10f;
        }
        else if (fat < 40)
        {
            spriteRenderer.sprite = normalSprite;
            newAnim = normalAnim;
            playerController.MoveSpeed = 5f;
            playerController.JumpForce = 7f;
        }
        else if (fat < 60)
        {
            spriteRenderer.sprite = fatSprite;
            newAnim = fatAnim;
            playerController.MoveSpeed = 4f;
            playerController.JumpForce = 6f;
        }
        else if (fat < 100)
        {
            spriteRenderer.sprite = superFatSprite;
            newAnim = superFatAnim; 
            playerController.MoveSpeed = 3f;
            playerController.JumpForce = 5f;
        }
        else
        {
            Destroy(gameObject);
        }

        if (newAnim != currentAnim)
        {
            currentAnim = newAnim;
            animator.runtimeAnimatorController = currentAnim;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Checkpoint"))
        {
            Checkpoint checkpoint = collision.GetComponent<Checkpoint>();

            if (checkpoint != null)
            {
                checkpoint.Activate(); 
            }
        }

        if(collision.CompareTag("Exit"))
        {
            Time.timeScale = 0f;
            finishGameUI.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Trap"))
        {
            Respawn();
        }

        if (collision.collider.CompareTag("Dead"))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = CheckpointManager.Instance.GetRespawnPosition();
    }
}
