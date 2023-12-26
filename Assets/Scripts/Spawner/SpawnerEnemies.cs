using System.Collections;
using UnityEngine;

public class SpawnerEnemies : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private SpawnerBullets _spawnerBullets;

    private Coroutine _releaseEnemy;

    private void Awake()
    {
        Initializ(_template);

        foreach (var item in Pool)
            item.GetComponent<EnemyShoot>().Init(_spawnerBullets);

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
        WaitForSeconds cooldown = new WaitForSeconds(_secondsBetweenSpawn);
        
        while (enabled)
        {
            if (TryGetObject(out GameObject enemy))
                ActivateEnemy(enemy);

            yield return cooldown;
        }
    }
}