using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _attackRate = 0.1f;
    [SerializeField] AudioSource _audioSource;

    public void StartFiring()
    {
        StartCoroutine(nameof(TryAttack));
    }

    public void StopFiring()
    {
        StopCoroutine(nameof(TryAttack));
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            _audioSource.Play();

            yield return new WaitForSeconds(_attackRate);
        }
    }
}
