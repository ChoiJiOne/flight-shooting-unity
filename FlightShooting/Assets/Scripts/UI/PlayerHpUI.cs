using UnityEngine;
using UnityEngine.UI;

public class PlayerHpUI : MonoBehaviour
{
    [SerializeField] private PlayerHp _playerHp;
    [SerializeField] private Slider _hpSlider;

    private void Update()
    {
        _hpSlider.value = _playerHp.CurrentHp / _playerHp.MaxHp;
    }
}
