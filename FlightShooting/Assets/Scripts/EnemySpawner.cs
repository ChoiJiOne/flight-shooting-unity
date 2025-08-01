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

    [SerializeField] private int _maxEnemyCount = 100;

    [Header("Boss")]
    [SerializeField] private GameObject _boss;
    [SerializeField] private BGMController _bgmController;
    [SerializeField] private GameObject _bossWarningText;
    [SerializeField] private GameObject _bossHpUI;
    
    private void Awake()
    {
        _bossWarningText.SetActive(false);
        _boss.SetActive(false);
        _bossHpUI.SetActive(false);

        StartCoroutine(nameof(SpawnEnemy));
    }

    private IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0;

        while (true)
        {
            float positionX = Random.Range(_stageData.LimitMin.x, _stageData.LimitMax.x);
            Vector3 position = new Vector3(positionX, _stageData.LimitMax.y + 1.0f, 0.0f);

            GameObject enemyClone = Instantiate(_enemyPrefab, position, Quaternion.identity);
            SpawnEnemyHp(enemyClone);

            currentEnemyCount++;
            if (currentEnemyCount == _maxEnemyCount)
            {
                StartCoroutine(nameof(SpawnBoss));
                break;
            }

            yield return new WaitForSeconds(_spawnTime);
        }
    }

    private void SpawnEnemyHp(GameObject enemy)
    {
        GameObject enemyHpClone = Instantiate(_enemyHpPrefab);
        enemyHpClone.transform.SetParent(_canvasTransform);
        enemyHpClone.transform.localScale = Vector3.one;

        enemyHpClone.GetComponent<SliderPositionAudoSetter>().Setup(enemy.transform);
        enemyHpClone.GetComponent<EnemyHpUI>().Setup(enemy.GetComponent<CharacterHp>());
    }

    private IEnumerator SpawnBoss()
    {
        _bgmController.ChangeBGM(EBGM.BOSS);

        _bossWarningText.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _bossWarningText.SetActive(false);
        _bossHpUI.SetActive(true);
        _boss.SetActive(true);
        _boss.GetComponent<BossController>().ChangeState(EBossState.MOVE_TO_APPEAR_POINT);
    }
}
