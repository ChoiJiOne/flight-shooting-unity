using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    [SerializeField] private StageData _stageData;
    [SerializeField] private float _destroyWeight = 2.0f;

    private void LateUpdate()
    {
        if (transform.position.y < _stageData.LimitMin.y - _destroyWeight ||
            transform.position.y > _stageData.LimitMax.y + _destroyWeight ||
            transform.position.x < _stageData.LimitMin.x - _destroyWeight ||
            transform.position.x > _stageData.LimitMax.x + _destroyWeight)
        {
            Destroy(gameObject);
        }
    }
}