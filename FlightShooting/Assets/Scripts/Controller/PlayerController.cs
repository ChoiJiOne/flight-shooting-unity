using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int Score
    {
        set => _score = Mathf.Max(0, value);
        get => _score;
    }

    [Header("Stage")]
    [SerializeField] private StageData _stageData;

    [Header("Controller")]
    [SerializeField] private MovementController _movementController;
    [SerializeField] private WeaponController _weaponController;

    [Header("KeyCode")]
    [SerializeField] private KeyCode _keyCodeAttack = KeyCode.Space;
    [SerializeField] private KeyCode _KeyCodeBoom = KeyCode.Z;

    [Header("Scene")]
    [SerializeField] private string _nextSceneName;

    [Header("Animation")]
    [SerializeField] private Animator _animator;

    private bool _isDie = false;
    private int _score;

    private void Update()
    {
        if (_isDie)
        {
            return;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        _movementController.MoveTo(new Vector3(x, y, 0.0f));

        if (Input.GetKeyDown(_keyCodeAttack))
        {
            _weaponController.StartFiring();
        }
        else if (Input.GetKeyUp(_keyCodeAttack))
        {
            _weaponController.StopFiring();
        }

        if (Input.GetKeyDown(_KeyCodeBoom))
        {
            _weaponController.StartBoom();
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, _stageData.LimitMin.x, _stageData.LimitMax.x),
            Mathf.Clamp(transform.position.y, _stageData.LimitMin.y, _stageData.LimitMax.y)
        );
    }

    public void OnDie()
    {
        _movementController.MoveTo(Vector3.zero);
        _animator.SetTrigger(nameof(OnDie));

        Destroy(GetComponent<CircleCollider2D>());

        _isDie = true;
    }

    public void OnDieEvent()
    {
        PlayerPrefs.SetInt(nameof(Score), Score);
        SceneManager.LoadScene(_nextSceneName);
    }
}
