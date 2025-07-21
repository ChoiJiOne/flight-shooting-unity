using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private GameObject _explosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHp>().TakeDamage(_damage);
            OnDie();
        }
    }

    public void OnDie()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}