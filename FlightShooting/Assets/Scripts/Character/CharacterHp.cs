using System.Collections;
using UnityEngine;

public class CharacterHp : MonoBehaviour
{
    public float MaxHp => _maxHp;
    public float CurrentHp
    {
        get => _currentHp;
        set => _currentHp = Mathf.Clamp(value, 0, _maxHp);
    }

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _hitColor;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private float _maxHp;
    [SerializeField] private float _damageFlashDuration = 0.1f;

    private float _currentHp;
    private ICharacterController _characterController;

    private void Awake()
    {
        _currentHp = _maxHp;
    }

    public void SetCharacterController(ICharacterController characterController)
    {
        _characterController = characterController;
    }

    public void TakeDamage(float damage)
    {
        _currentHp -= damage;

        StopCoroutine(nameof(HitColorAnimation));
        StartCoroutine(nameof(HitColorAnimation));

        if (_currentHp <= 0.0f)
        {
            _characterController.OnDie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        _spriteRenderer.color = _hitColor;
        yield return new WaitForSeconds(_damageFlashDuration);
        _spriteRenderer.color = _defaultColor;
    }
}
