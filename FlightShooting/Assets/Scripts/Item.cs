using UnityEngine;

public enum ItemType
{
    POWER_UP = 0,
}

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType _itemType;
    [SerializeField] private MovementController _moveController;

    private void Awake()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);

        _moveController.MoveTo(new Vector3(x, y, 0.0f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Use(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void Use(GameObject player)
    {
        switch (_itemType)
        {
            case ItemType.POWER_UP:
                player.GetComponent<WeaponController>().AttackLevel++;
                break;
        }
    }
}
