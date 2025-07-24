using System.Collections;
using UnityEngine;

public enum EBossState
{
    MoveToAppearPoint,
}

public class BossController : MonoBehaviour
{
    [SerializeField] private float _bossAppearPoint = 2.5f;
    [SerializeField] private EBossState _bossState = EBossState.MoveToAppearPoint;
    [SerializeField] private MovementController _moveController;

    public void ChangeState(EBossState newState)
    {
        StopCoroutine(_bossState.ToString());
        _bossState = newState;
        StartCoroutine(_bossState.ToString());
    }

    private IEnumerator MoveToAppearPoint()
    {
        _moveController.MoveTo(Vector3.down);

        while (true)
        {
            if (transform.position.y <= _bossAppearPoint)
            {
                _moveController.MoveTo(Vector3.zero);
            }

            yield return null;
        }
    }
}
