using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] int _scorePoint = 100;

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
        Destroy(gameObject);
    }
}