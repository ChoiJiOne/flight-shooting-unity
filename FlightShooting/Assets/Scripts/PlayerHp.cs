using System.Collections;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public float MaxHp => _maxHp;
    public float CurrentHp => _currentHp;

    [SerializeField] private float _maxHp = 10.0f;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float _currentHp = 0.0f;

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
            Debug.Log($"Player HP: {_currentHp}... Die");
        }
    }

    private IEnumerator HitColorAnimation()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = Color.white;
    }
}
