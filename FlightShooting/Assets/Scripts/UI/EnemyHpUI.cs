using UnityEngine;
using UnityEngine.UI;

public class EnemyHpUI : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;

    private EnemyHp _enemyHp;

    public void Setup(EnemyHp enemyHp)
    {
        _enemyHp = enemyHp;
    }

    private void Update()
    {
        _hpSlider.value = _enemyHp.CurrentHp / _enemyHp.MaxHp;
    }
}
