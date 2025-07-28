using UnityEngine;
using UnityEngine.UI;

public class BossHpUI : MonoBehaviour
{
    [SerializeField] private CharacterHp _bossHp;
    [SerializeField] private Slider _sliderHp;

    private void Update()
    {
        _sliderHp.value = _bossHp.CurrentHp / _bossHp.MaxHp;
    }
}
