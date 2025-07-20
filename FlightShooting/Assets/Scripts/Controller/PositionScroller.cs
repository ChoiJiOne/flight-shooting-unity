using UnityEngine;

public class PositionScroller : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _scrollRange = 9.9f;
    [SerializeField] private float _moveSpeed = 3.0f;
    [SerializeField] private Vector3 _moveDirection = Vector3.down;

    private void Update()
    {
        transform.position += _moveDirection * _moveSpeed * Time.deltaTime;

        if (transform.position.y <= -_scrollRange)
        {
            transform.position = _target.position + Vector3.up * _scrollRange;
        }
    }
}
