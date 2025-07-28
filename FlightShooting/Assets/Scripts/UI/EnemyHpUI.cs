using UnityEngine;
using UnityEngine.UI;

public class EnemyHpUI : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;

    private CharacterHp _enemyHp;

    public void Setup(CharacterHp enemyHp)
    {
        _enemyHp = enemyHp;
    }

    private void Update()
    {
        _hpSlider.value = _enemyHp.CurrentHp / _enemyHp.MaxHp;
    }
}
