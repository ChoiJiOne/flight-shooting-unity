using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBossState
{
    MOVE_TO_APPEAR_POINT,
    PHASE_01,
    PHASE_02,
}

public class BossController : MonoBehaviour
{
    [SerializeField] private StageData _stageData;
    [SerializeField] private float _bossAppearPoint = 2.5f;
    [SerializeField] private EBossState _bossState = EBossState.MOVE_TO_APPEAR_POINT;
    [SerializeField] private MovementController _moveController;
    [SerializeField] private BossWeaponController _weaponController;
    [SerializeField] private BossHp _bossHp;

    private Dictionary<EBossState, string> _bossStateExecuteDic;

    private void Awake()
    {
        _bossStateExecuteDic = new()
        {
            { EBossState.MOVE_TO_APPEAR_POINT, nameof(MoveToAppearPoint) },
            { EBossState.PHASE_01, nameof(Phase01) },
            { EBossState.PHASE_02, nameof(Phase02) },
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
            if (_bossHp.CurrentHp <= _bossHp.MaxHp * 0.7f)
            {
                _weaponController.StopFiring(EAttackType.CIRCLE_FILE);
                ChangeState(EBossState.PHASE_02);
            }

            yield return null;
        }
    }

    private IEnumerator Phase02()
    {
        _weaponController.StartFiring(EAttackType.SINGLE_FIRE_TO_CENTER_POSITION);

        Vector3 direction = Vector3.right;
        _moveController.MoveTo(direction);

        while (true)
        {
            if (transform.position.x <= _stageData.LimitMin.x || transform.position.x >= _stageData.LimitMax.x)
            {
                direction *= -1.0f;
                _moveController.MoveTo(direction);
            }

            yield return null;
        }
    }
}
