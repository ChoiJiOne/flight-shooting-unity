using UnityEngine;
using TMPro;

public class PlayerBoomCountUI : MonoBehaviour
{
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private TextMeshProUGUI _boomCountText;

    private void Update()
    {
        _boomCountText.text = $"x {_weaponController.BoomCount}";
    }
}