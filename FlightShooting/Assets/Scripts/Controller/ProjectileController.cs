using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().OnDie();
            Destroy(gameObject);
        }
    }
}
