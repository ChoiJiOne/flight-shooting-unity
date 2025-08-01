using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour, ICharacterController
{
    [SerializeField] private StageData _stageData;
    [SerializeField] private float _bossAppearPoint = 2.5f;
    [SerializeField] private EBossState _bossState = EBossState.MOVE_TO_APPEAR_POINT;
    [SerializeField] private MovementController _moveController;
    [SerializeField] private BossWeaponController _weaponController;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private string _nextSceneName;

    [Header("Character")]
    [SerializeField] private CharacterHp _bossHp;

    private Dictionary<EBossState, string> _bossStateExecuteDic;

    private void Awake()
    {
        _bossStateExecuteDic = new()
        {
            { EBossState.MOVE_TO_APPEAR_POINT, nameof(MoveToAppearPoint) },
            { EBossState.PHASE_01, nameof(Phase01) },
            { EBossState.PHASE_02, nameof(Phase02) },
            { EBossState.PHASE_03, nameof(Phase03) },
        };

        _bossHp.SetCharacterController(this);
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
        _weaponController.StartFiring(EBossAttackPattern.CIRCLE_FILE);

        while (true)
        {
            if (_bossHp.CurrentHp <= _bossHp.MaxHp * 0.7f)
            {
                _weaponController.StopFiring(EBossAttackPattern.CIRCLE_FILE);
                ChangeState(EBossState.PHASE_02);
            }

            yield return null;
        }
    }

    private IEnumerator Phase02()
    {
        _weaponController.StartFiring(EBossAttackPattern.SINGLE_FIRE_TO_CENTER_POSITION);

        Vector3 direction = Vector3.right;
        _moveController.MoveTo(direction);

        while (true)
        {
            if (transform.position.x <= _stageData.LimitMin.x || transform.position.x >= _stageData.LimitMax.x)
            {
                direction *= -1.0f;
                _moveController.MoveTo(direction);
            }

            if (_bossHp.CurrentHp <= _bossHp.MaxHp * 0.3f)
            {
                _weaponController.StopFiring(EBossAttackPattern.SINGLE_FIRE_TO_CENTER_POSITION);
                ChangeState(EBossState.PHASE_03);
            }

            yield return null;
        }
    }

    private IEnumerator Phase03()
    {
        _weaponController.StartFiring(EBossAttackPattern.CIRCLE_FILE);
        _weaponController.StartFiring(EBossAttackPattern.SINGLE_FIRE_TO_CENTER_POSITION);
        
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

    public void OnDie()
    {
        GameObject clone = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        clone.GetComponent<BossExplosion>().Setup(_playerController, _nextSceneName);

        Destroy(gameObject);
    }
}
