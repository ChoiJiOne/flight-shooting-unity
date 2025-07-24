using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBossState
{
    MOVE_TO_APPEAR_POINT,
    PHASE_01,
}

public class BossController : MonoBehaviour
{
    [SerializeField] private float _bossAppearPoint = 2.5f;
    [SerializeField] private EBossState _bossState = EBossState.MOVE_TO_APPEAR_POINT;
    [SerializeField] private MovementController _moveController;
    [SerializeField] private BossWeaponController _weaponController;

    private Dictionary<EBossState, string> _bossStateExecuteDic;

    private void Awake()
    {
        _bossStateExecuteDic = new()
        {
            { EBossState.MOVE_TO_APPEAR_POINT, nameof(MoveToAppearPoint) },
            { EBossState.PHASE_01, nameof(Phase01) },
        };
    }

    public void ChangeState(EBossState newState)
    {
        StopCoroutine(_bossStateExecuteDic[_bossState]);
        _bossState = newState;
        StartCoroutine(_bossStateExecuteDic[_bossState]);
    }

    private IEnumerator MoveToAppearPoint()
    {
        _moveController.MoveTo(Vector3.down);

        while (true)
        {
            if (transform.position.y <= _bossAppearPoint)
            {
                _moveController.MoveTo(Vector3.zero);
                ChangeState(EBossState.PHASE_01);
            }

            yield return null;
        }
    }

    private IEnumerator Phase01()
    {
        _weaponController.StartFiring(EAttackType.CIRCLE_FILE);

        while (true)
        {
            yield return null;
        }
    }
}
