using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private StageData _stageData;
    [SerializeField] private MovementController _movementController;

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        _movementController.MoveTo(new Vector3(x, y, 0.0f));
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, _stageData.LimitMin.x, _stageData.LimitMax.x),
            Mathf.Clamp(transform.position.y, _stageData.LimitMin.y, _stageData.LimitMax.y)
        );
    }
}
