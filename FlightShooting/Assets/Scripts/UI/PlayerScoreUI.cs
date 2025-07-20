using UnityEngine;
using TMPro;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Update()
    {
        _scoreText.text = $"Score {_playerController.Score}";
    }
}