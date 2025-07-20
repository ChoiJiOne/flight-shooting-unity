using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private StageData _stageData;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnTime;

    private void Awake()
    {
        StartCoroutine(nameof(SpawnEnemy));
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float positionX = Random.Range(_stageData.LimitMin.x, _stageData.LimitMax.x);
            Instantiate(_enemyPrefab, new Vector3(positionX, _stageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
