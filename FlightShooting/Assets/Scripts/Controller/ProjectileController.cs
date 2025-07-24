using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHp>().TakeDamage(_damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHp>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
