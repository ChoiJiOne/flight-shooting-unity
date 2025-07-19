using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MovementController _movementController;

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        _movementController.MoveTo(new Vector3(x, y, 0.0f));
    }
}
