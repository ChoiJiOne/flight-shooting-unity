using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private string _targetScene;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(() => SceneLoader(_targetScene));
    }

    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}