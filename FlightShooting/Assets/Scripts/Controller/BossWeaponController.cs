using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EAttackType
{
    CIRCLE_FILE = 0,
    SINGLE_FIRE_TO_CENTER_POSITION,
}

public class BossWeaponController : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;

    private Dictionary<EAttackType, string> _attackExecuteDic;

    private void Awake()
    {
        _attackExecuteDic = new()
        {
            {EAttackType.CIRCLE_FILE, nameof(CircleFire) },
            {EAttackType.SINGLE_FIRE_TO_CENTER_POSITION, nameof(SingleFireToCenterPosition) },
        };
    }

    public void StartFiring(EAttackType attackType)
    {
        StartCoroutine(_attackExecuteDic[attackType]);
    }

    public void StopFiring(EAttackType attackType)
    {
        StopCoroutine(_attackExecuteDic[attackType]);
    }

    private IEnumerator CircleFire()
    {
        float attackRate = 0.5f;
        int count = 30;
        float intervalAngle = 360.0f / count;
        float weightAngle = 0.0f;

        while (true)
        {
            for (int idx = 0; idx < count; ++idx)
            {
                GameObject clone = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);

                float angle = weightAngle + intervalAngle * idx;

                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);

                clone.GetComponent<MovementController>().MoveTo(new Vector2(x, y));
            }

            weightAngle += 1;

            yield return new WaitForSeconds(attackRate);
        }
    }

    private IEnumerator SingleFireToCenterPosition()
    {
        Vector3 targetPosition = Vector3.zero;
        float attackRate = 0.1f;

        while (true)
        {
            GameObject clone = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);

            Vector3 direction = (targetPosition - clone.transform.position).normalized;
            clone.GetComponent<MovementController>().MoveTo(direction);

            yield return new WaitForSeconds(attackRate);
        }
    }
}
