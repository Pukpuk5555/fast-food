using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStats fat;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField]
    private Sprite healthySprite, fatSprite, superFatSprite;

    [SerializeField]
    private RuntimeAnimatorController healthyAnim, fatAnim, superFatAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
