using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemiesVersion2 : ObjectPoolVersion2
{
    [SerializeField] private List<GameObject> _enemiesPrefab; 
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private SpawnerBulletsVersion2 _spawnerBullets;

    private Coroutine _releaseEnemy;

    private void Awake()
    {
        LaunchLiberationEnemies();
    }

    private void OnDisable()
    {
        StopReleaseEnemy();
    }

    public void LaunchLiberationEnemies()
    {
        StopReleaseEnemy();
        _releaseEnemy = StartCoroutine(ReleaseEnemy());
    }

    protected override void InitObject(GameObject result)
    {
        base.InitObject(result);
        result.GetComponent<EnemyShootVersion2>().Init(_spawnerBullets);
    }

    private void ActivateEnemy(GameObject enemy)
    {
        float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
        enemy.transform.position = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        enemy.SetActive(true);
    }

    private void StopReleaseEnemy()
    {
        if (_releaseEnemy != null)
            StopCoroutine(_releaseEnemy);
    }

    private IEnumerator ReleaseEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(_secondsBetweenSpawn);
        GameObject enemy;

        while (enabled)
        {
            enemy = GetObject(_enemiesPrefab);
            ActivateEnemy(enemy);

            yield return wait;
        }
    }
}