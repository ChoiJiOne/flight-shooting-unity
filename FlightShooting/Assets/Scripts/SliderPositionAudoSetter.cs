using UnityEngine;

public class SliderPositionAudoSetter : MonoBehaviour
{
    [SerializeField] private Vector3 _distance = Vector3.down * 35.0f;
    [SerializeField] private RectTransform _rectTransform;

    private Transform _targetTransform;

    public void Setup(Transform target)
    {
        _targetTransform = target;
    }

    private void LateUpdate()
    {
        if (_targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(_targetTransform.position);
        _rectTransform.position = screenPosition + _distance;
    }
}
