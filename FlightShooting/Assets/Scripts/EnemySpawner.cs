using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Ingame Enemy")]
    [SerializeField] private StageData _stageData;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnTime;

    [Header("Enemy UI")]
    [SerializeField] private GameObject _enemyHpPrefab;
    [SerializeField] private Transform _canvasTransform;

    private void Awake()
    {
        StartCoroutine(nameof(SpawnEnemy));
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float positionX = Random.Range(_stageData.LimitMin.x, _stageData.LimitMax.x);
            Vector3 position = new Vector3(positionX, _stageData.LimitMax.y + 1.0f, 0.0f);

            GameObject enemyClone = Instantiate(_enemyPrefab, position, Quaternion.identity);
            SpawnEnemyHp(enemyClone);

            yield return new WaitForSeconds(_spawnTime);
        }
    }

    private void SpawnEnemyHp(GameObject enemy)
    {
        GameObject enemyHpClone = Instantiate(_enemyHpPrefab);
        enemyHpClone.transform.SetParent(_canvasTransform);
        enemyHpClone.transform.localScale = Vector3.one;

        enemyHpClone.GetComponent<SliderPositionAudoSetter>().Setup(enemy.transform);
    }
}
