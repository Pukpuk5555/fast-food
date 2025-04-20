using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Sprite activatedSprite;
    [SerializeField] private Sprite defaultSprite;

    private SpriteRenderer spriteRenderer;
    private bool isActivated = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
    }

    public void Activate()
    {
        if (!isActivated)
        {
            isActivated = true;
            spriteRenderer.sprite = activatedSprite;
        }
        CheckpointManager.Instance.SetCheckpoint(this);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
