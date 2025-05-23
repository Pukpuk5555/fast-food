using UnityEngine;
public enum ItemType
{
    Salad,
    Weight,
    Burger,
    Cola,
    Energy
}

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] ItemType itemType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStats player = other.GetComponent<PlayerStats>();
        PlayerController controller = other.GetComponent<PlayerController>();

        if(player != null)
        {
            switch (itemType)
            {
                case ItemType.Salad:
                    player.ReduceFat(10);
                    break;
                case ItemType.Weight:
                    player.ReduceFat(5);
                    break;
                case ItemType.Burger:
                    player.IncreaseFat(20);
                    break;
                case ItemType.Cola:
                    player.IncreaseFat(10);
                    break;
                case ItemType.Energy:
                    controller.StartSpeedBoost();
                    break;
            }
            Destroy(gameObject);    
        }
    }
}
