using UnityEngine;
using UnityEngine.SceneManagement;

public class BossExplosion : MonoBehaviour
{
    private PlayerController _playerController;
    private string _sceneName;

    public void Setup(PlayerController playerController, string sceneName)
    {
        _playerController = playerController;
        _sceneName = sceneName;
    }

    private void OnDestroy()
    {
        _playerController.Score += 10000;
        PlayerPrefs.SetInt("Score", _playerController.Score);
        SceneManager.LoadScene(_sceneName);
    }
}
