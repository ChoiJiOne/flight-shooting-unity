using System.Collections;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    [SerializeField] private float _maxHp = 1000.0f;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float _currentHp;

    private void Awake()
    {
        _currentHp = _maxHp;
    }

    public void TakeDamage(float damage)
    {
        _currentHp -= damage;

        StopCoroutine(nameof(HitColorAnimation));
        StartCoroutine(nameof(HitColorAnimation));

        if (_currentHp <= 0.0f)
        {

        }
    }

    private IEnumerator HitColorAnimation()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        _spriteRenderer.color = Color.white;
    }
}
