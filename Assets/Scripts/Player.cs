using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStats stats;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField]
    private Sprite healthySprite, normalSprite, fatSprite, superFatSprite;

    [SerializeField]
    private RuntimeAnimatorController healthyAnim, normalAnim, fatAnim, superFatAnim;

    private RuntimeAnimatorController currentAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); 
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
        }
        else if (fat < 40)
        {
            spriteRenderer.sprite = normalSprite;
            newAnim = normalAnim;
        }
        else if (fat < 60)
        {
            spriteRenderer.sprite = fatSprite;
            newAnim = fatAnim;
        }
        else if (fat < 100)
        {
            spriteRenderer.sprite = superFatSprite;
            newAnim = superFatAnim;
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
}
