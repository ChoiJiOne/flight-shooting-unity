using System.Collections;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private AudioClip _boomAudio;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private int _boomDamage = 100;

    private float _boomDelay = 0.5f;
    
    private void Awake()
    {
        StartCoroutine(nameof(MoveToCenter));
    }

    private IEnumerator MoveToCenter()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Vector3.zero;
        float current = 0.0f;
        float percent = 0.0f;

        while (percent < 1.0)
        {
            current += Time.deltaTime;
            percent = current / _boomDelay;

            transform.position = Vector3.Lerp(startPosition, endPosition, _curve.Evaluate(percent));

            yield return null;
        }

        _animator.SetTrigger(nameof(OnBoom));
        _audioSource.clip = _boomAudio;
        _audioSource.Play();
    }

    public void OnBoom()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] meteorites = GameObject.FindGameObjectsWithTag("Meteorite");

        foreach (var enemy in enemys)
        {
            enemy.GetComponent<EnemyController>().OnDie();
        }

        foreach (var meteorite in meteorites)
        {
            meteorite.GetComponent<MeteoriteController>().OnDie();
        }

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        for (int idx = 0; idx < projectiles.Length; idx++)
        {
            projectiles[idx].GetComponent<EnemyProjectileController>().OnDie();
        }

        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            boss.GetComponent<CharacterHp>().TakeDamage(_boomDamage);
        }

        Destroy(gameObject);
    }
}