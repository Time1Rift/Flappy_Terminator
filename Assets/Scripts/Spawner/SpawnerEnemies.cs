using System.Collections;
using UnityEngine;

public class SpawnerEnemies : ObjectPool<Enemy>
{
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private SpawnerBullets _spawnerBullets;

    private Coroutine _releaseEnemy;

    private void OnDisable()
    {
        StopReleaseEnemy();
    }

    public void LaunchLiberationEnemies()
    {
        StopReleaseEnemy();
        _releaseEnemy = StartCoroutine(ReleaseEnemy());
    }

    public void StopReleaseEnemy()
    {
        if (_releaseEnemy != null)
            StopCoroutine(_releaseEnemy);
    }

    private void ActivateEnemy(Enemy enemy)
    {
        enemy.GetComponent<EnemyShoot>().Init(_spawnerBullets);
        float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
        enemy.transform.position = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        enemy.gameObject.SetActive(true);
    }

    private IEnumerator ReleaseEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(_secondsBetweenSpawn);

        while (enabled)
        {
            Enemy enemy = GetObject(Prefab);
            ActivateEnemy(enemy);

            yield return wait;
        }
    }
}