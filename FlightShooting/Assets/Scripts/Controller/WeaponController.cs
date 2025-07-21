using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int AttackLevel
    {
        set => _attackLevel = Mathf.Clamp(value, 1, _maxAttackLevel);
        get => _attackLevel;
    }
    public int BoomCount
    {
        set => _boomCount = Mathf.Max(0, value);
        get => _boomCount;
    }

    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _attackRate = 0.1f;
    [SerializeField] private int _maxAttackLevel = 3;
    [SerializeField] AudioSource _audioSource;

    [Header("Boom")]
    [SerializeField] private GameObject _boomPrefab;
    
    private int _attackLevel = 1;
    private int _boomCount = 3;

    public void StartFiring()
    {
        StartCoroutine(nameof(TryAttack));
    }

    public void StopFiring()
    {
        StopCoroutine(nameof(TryAttack));
    }

    public void StartBoom()
    {
        if (_boomCount > 0)
        {
            _boomCount--;
            Instantiate(_boomPrefab, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            AttackByLevel();
            _audioSource.Play();

            yield return new WaitForSeconds(_attackRate);
        }
    }

    private void AttackByLevel()
    {
        GameObject projectileClone = null;

        switch (_attackLevel)
        {
            case 1:
                Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
                break;

            case 2:
                Instantiate(_projectilePrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(_projectilePrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;

            case 3:
                Instantiate(_projectilePrefab, transform.position, Quaternion.identity);

                projectileClone = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
                projectileClone.GetComponent<MovementController>().MoveTo(new Vector3(-0.2f, 1.0f, 0.0f));

                projectileClone = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
                projectileClone.GetComponent<MovementController>().MoveTo(new Vector3(0.2f, 1.0f, 0.0f));
                break;
        }
    }
}
