using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] int _scorePoint = 100;
    [SerializeField] GameObject _explosionPrefab;
    [SerializeField] private GameObject[] _itemPrefabs;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

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
        _playerController.Score += _scorePoint;

        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

        SpawnItem();

        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        int spawnItem = Random.Range(0, 100);
        if (spawnItem < 40)
        {
            Instantiate(_itemPrefabs[0], transform.position, Quaternion.identity);
        }
        else if (spawnItem < 90)
        {
            Instantiate(_itemPrefabs[1], transform.position, Quaternion.identity);
        }
    }
}