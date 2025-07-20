using TMPro;
using UnityEngine;

public class ResultScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultScoreText;

    private void Awake()
    {
        int score = PlayerPrefs.GetInt("Score");
        _resultScoreText.text = $"Result Score {score}";
    }
}
