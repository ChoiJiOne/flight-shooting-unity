using System.Collections;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    [SerializeField] private StageData _stageData;
    [SerializeField] private GameObject _alertLinePrefab;
    [SerializeField] private GameObject _meteoritePrefab;
    [SerializeField] private float _minSpawnTime = 1.0f;
    [SerializeField] private float _maxSpawnTime = 4.0f;

    private void Awake()
    {
        StartCoroutine(nameof(SpawnMeteorite));
    }

    private IEnumerator SpawnMeteorite()
    {
        while (true)
        {
            float positionX = Random.Range(_stageData.LimitMin.x, _stageData.LimitMax.x);
            GameObject alertLine = Instantiate(_alertLinePrefab, new Vector3(positionX, 0.0f, 0.0f), Quaternion.identity);

            yield return new WaitForSeconds(1.0f);

            Destroy(alertLine);

            Vector3 meteoritePosition = new Vector3(positionX, _stageData.LimitMax.y + 1.0f, 0.0f);
            Instantiate(_meteoritePrefab, meteoritePosition, Quaternion.identity);

            float spawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
